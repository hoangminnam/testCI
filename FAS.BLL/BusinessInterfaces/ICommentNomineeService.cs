using FAS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.BLL.BusinessInterfaces
{
    public interface ICommentNomineeService
    {
        public Task<IEnumerable<CommentNominee>> GetCommentNominees();
        public Task<CommentNominee?> GetCommentNominee(Guid id);
        public Task UpdateCommentNominee(Guid id, CommentNominee commentNominee);
        public Task<CommentNominee> AddCommentNominee(CommentNominee commentNominee);
        public Task DeleteCommentNominee(Guid id);
    }
}
