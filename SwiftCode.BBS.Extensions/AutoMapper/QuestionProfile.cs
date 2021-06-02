using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SwiftCode.BBS.Model.Models;
using SwiftCode.BBS.Model.ViewModels.Article;
using SwiftCode.BBS.Model.ViewModels.Question;

namespace SwiftCode.BBS.Extensions.AutoMapper
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<CreateQuestionInputDto, Question>();
            CreateMap<UpdateQuestionInputDto, Question>();

            CreateMap<Question, QuestionDto>();
            CreateMap<Question, QuestionDetailsDto>();
            CreateMap<QuestionComment, QuestionCommentDto>();


            CreateMap<CreateQuestionCommentsInputDto, QuestionComment>();
        }
    }
}
