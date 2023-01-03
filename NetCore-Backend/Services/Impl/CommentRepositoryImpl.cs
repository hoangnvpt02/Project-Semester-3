using NetCore_Backend.Models;
using NetCore_Backend.Data;

namespace NetCore_Backend.Services.Impl
{
    public class CommentRepositoryImpl : ICommentRepository
    {
        private readonly MyDbContext _context;
        public CommentRepositoryImpl(MyDbContext context)
        {
            _context = context;
        }

        public CommentModel Add(CommentModel commentModel)
        {
            var comment = new Comment();
            comment.Content = commentModel.Content;
            comment.AspNetUsersId = commentModel.AspNetUsersId;
            comment.ProductId = commentModel.ProductId;
            comment.IsActive = commentModel.IsActive;
            comment.Updated = commentModel.Updated;
            comment.Created = commentModel.Created;
            _context.Add(comment);
            _context.SaveChanges();
            return new CommentModel()
            {
                Id = comment.Id,
                Content = comment.Content,
                IsActive = comment.IsActive,
                Updated = comment.Updated,
                Created = comment.Created,
                AspNetUsersId = comment.AspNetUsersId,
                ProductId = comment.ProductId,
            };
        }

        public void Delete(long id)
        {
            var comment = _context.Comments.FirstOrDefault(c => c.Id == id);
            if(comment != null)
            {
                _context.Comments.Remove(comment);
                _context.SaveChanges();
            }
        }

        public List<CommentModel> GetAll()
        {
            var comments = _context.Comments.Select(c => new CommentModel()
            {
                Id = c.Id,
                Content = c.Content,
                IsActive = c.IsActive,
                Updated = c.Updated,
                Created = c.Created,
                AspNetUsersId = c.AspNetUsersId,
                ProductId = c.ProductId,
            });
            return comments.ToList();
        }

        public CommentModel GetById(long id)
        {
           var comment = _context.Comments.FirstOrDefault(c => c.Id == id);
            if(comment != null)
            {
                return new CommentModel()
                {
                    Id = comment.Id,
                    Content = comment.Content,
                    IsActive = comment.IsActive,
                    Updated = comment.Updated,
                    Created = comment.Created,
                    AspNetUsersId = comment.AspNetUsersId,
                    ProductId = comment.ProductId,
                };
            }
            return null;
        }

        public void Update(CommentModel commentModel)
        {
            var comment = _context.Comments.FirstOrDefault(c => c.Id == commentModel.Id);
            if(comment != null)
            {
                comment.AspNetUsersId = commentModel.AspNetUsersId;
                comment.Content = commentModel.Content;
                comment.IsActive = commentModel.IsActive;
                comment.Updated = commentModel.Updated;
                comment.ProductId = commentModel.ProductId;
                _context.Update(comment);
                _context.SaveChanges();
            }
        }
    }
}
