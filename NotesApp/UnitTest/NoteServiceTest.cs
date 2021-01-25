using Xunit;
using System;

using Moq;
using NotesApp.Services.Abstractions;
using NotesApp.Services.Models;
using NotesApp.Services.Services;


namespace UnitTest
{

    public class NoteServiceTest
    {


        [Fact]
        public void AddNote_Failed_If_Note_is_Null()
        {
            var mockEvents = new Mock<INoteEvents>();
            var mockStorage = new Mock<INotesStorage>();

            var service = new NotesService(mockStorage.Object, mockEvents.Object);
            Assert.Throws<ArgumentNullException>(() => service.AddNote(null, 1));
        }

        [Fact]
        public void AddNote_NotifyAdded_Successful()
        {
            var note = new Note();

            var mockEvents = new Mock<INoteEvents>();
            var mockStorage = new Mock<INotesStorage>();

            mockStorage.Setup(x => x.AddNote(note, 1));
            mockEvents.Setup(x => x.NotifyAdded(note, 1));

            var service = new NotesService(mockStorage.Object, mockEvents.Object);
            service.AddNote(note,1);

            mockEvents.Verify(x=>x.NotifyAdded(note,1),Times.Once);
            
        }
        [Fact]
        public void AddNote_NotifyAdded_Failed()
        {
           
            var mockEvents = new Mock<INoteEvents>();
            var mockStorage = new Mock<INotesStorage>();

            mockStorage.Setup(x => x.AddNote(It.IsAny<Note>(), It.IsAny<int>()));
            mockEvents.Setup(x => x.NotifyAdded(It.IsAny<Note>(), It.IsAny<int>()));

            var service = new NotesService(mockStorage.Object, mockEvents.Object);
            Assert.Throws<ArgumentNullException>(() => service.AddNote(It.IsAny<Note>(), It.IsAny<int>()));

            mockEvents.Verify(x => x.NotifyAdded(null, It.IsAny<int>()), Times.Never);
        }


        [Fact]
        public void DeleteNote_NotifyDeleted_Successful()
        {
            var guid = Guid.NewGuid();

        

            var mockEvents = new Mock<INoteEvents>();
            var mockStorage = new Mock<INotesStorage>();

            mockStorage.Setup(x=>x.DeleteNote(guid)).Returns(true);
            mockEvents.Setup(x => x.NotifyDeleted(guid, 1));

            var service = new NotesService(mockStorage.Object, mockEvents.Object);

            service.DeleteNote(guid, 1);

            mockEvents.Verify(x => x.NotifyDeleted(guid, 1), Times.Once);
        }
        [Fact]
        public void DeleteNote_NotifyDeleted_Failed()
        {
            


            var mockEvents = new Mock<INoteEvents>();
            var mockStorage = new Mock<INotesStorage>();

            mockStorage.Setup(x => x.DeleteNote(It.IsAny<Guid>())).Returns(false);
            mockEvents.Setup(x => x.NotifyDeleted(It.IsAny<Guid>(), 1));

            var service = new NotesService(mockStorage.Object, mockEvents.Object);

            service.DeleteNote(It.IsAny<Guid>(), 1);

            mockEvents.Verify(x => x.NotifyDeleted(It.IsAny<Guid>(), 1), Times.Never);
        }




    }
}