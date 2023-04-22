using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Model;
using Team.Tests.Helpers;

namespace Team.Tests.ModelsTests
{
    [TestClass]
    public class TaskTest
    {
        [TestMethod]
        public void AddComment_ShouldAddCommentToCommentsCollection()
        {
            var id = 1;
            string title = TaskData.ValidTitle;
            string description = TaskData.ValidDescription;
            int raiting = FeedbackData.ValidRating;

            var sut = new Feedback(id, title, description, raiting);
            var author = new Member("Pesho");
            var comment = new Comment("TestComment", author);

            sut.AddComment(comment);

            Assert.AreEqual(1, sut.Comments.Count);
            Assert.AreEqual(comment, sut.Comments[0]);
            Assert.AreEqual(author, sut.Comments[0].Author);

            sut.RemoveComment(comment);

            Assert.AreEqual(0, sut.Comments.Count);
        }
    }
}
