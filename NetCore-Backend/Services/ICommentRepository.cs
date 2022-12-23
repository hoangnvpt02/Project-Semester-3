using NetCore_Backend.Models;

namespace NetCore_Backend.Services
{
    public interface ICommentRepository
    {
        List<CommentModel> GetAll();
        CommentModel GetById(long id);
        CommentModel Add(CommentModel commentModel);
        void Update(CommentModel commentModel);
        void Delete(long id);
    }
}
