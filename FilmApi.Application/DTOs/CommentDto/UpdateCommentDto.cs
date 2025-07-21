using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmApi.Application.DTOs.CommentDto
{
    public class UpdateCommentDto
    {
        public int CommentId { get; set; }

        public string NameSurname { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string MessageDetails { get; set; }

        public DateTime SendDate{ get; set; }
    }
}