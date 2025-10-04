using FAS.BLL.BusinessInterfaces;
using FAS.DAL.Interfaces;
using FAS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.BLL.BusinessService
{
    public class CommentNomineeService : ICommentNomineeService
    {
        private readonly ICommentNomineeRepository _commentNomineeRepository;
        public CommentNomineeService(ICommentNomineeRepository commentNomineeRepository)
        {
            _commentNomineeRepository = commentNomineeRepository;
        }

        public async Task<CommentNominee> AddCommentNominee(CommentNominee commentNominee) => await _commentNomineeRepository.AddCommentNominee(commentNominee);

        public async Task DeleteCommentNominee(Guid id) => await _commentNomineeRepository.DeleteCommentNominee(id);

        public async Task<CommentNominee?> GetCommentNominee(Guid id) => await _commentNomineeRepository.GetCommentNominee(id);

        public async Task<IEnumerable<CommentNominee>> GetCommentNominees() => await _commentNomineeRepository.GetCommentNominees();

        public async Task UpdateCommentNominee(Guid id, CommentNominee commentNominee) => await _commentNomineeRepository.UpdateCommentNominee(id, commentNominee);
    }
}
