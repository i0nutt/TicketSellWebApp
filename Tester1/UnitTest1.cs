using Moq;
using System;
using System.Threading.Tasks;
using TicketSellWebApp.Exporter;
using TicketSellWebApp.Models;
using TicketSellWebApp.Repositories;
using TicketSellWebApp.Repositories.cs;
using TicketSellWebApp.Services;
using Xunit;

namespace Tester1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Ticket myTicket = new Ticket();
            myTicket.Id = 3212;
            myTicket.RowNumber = 10;
            myTicket.ColumnNumber = 20;
            myTicket.ShowNumber = 10;
            Show myShow = new Show();
            myShow.NumberOfTickets = 199;

            var t = new Mock<Task<int>>();
            t.Setup(t => t.Result).Returns(200);
            var t2 = new Mock<Task<Show>>();
            t2.Setup(t => t.Result).Returns(myShow);

            Ticket p = null;

            var t3 = new Mock<Task<Ticket>>();
            t3.Setup(t => t.Result).Returns(p);

            var mockRepository1 = new Mock<ITicketRepository<Ticket>>();
            var mockRepository2 = new Mock<IRepository<Show>>();
            mockRepository1.Setup(t => t.countByInfo(myTicket.ShowNumber)).Returns(t.Object);
            mockRepository2.Setup(t => t.FindById(myTicket.ShowNumber)).Returns(t2.Object);
            mockRepository1.Setup(t => t.findCopy(myTicket)).Returns(t3.Object);

            ITicketService<Ticket> testing = new TicketService(mockRepository1.Object, mockRepository2.Object);
            Assert.True(testing.Create(myTicket).Equals(false));

        }
    }
}
