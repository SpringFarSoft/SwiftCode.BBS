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

            CreateMap<Question, QuestionDto>()
                .ForMember(a => a.QuestionCommentCount, o => o.MapFrom(x => x.QuestionComments.Count));
          
            CreateMap<Question, QuestionDetailsDto>();


            CreateMap<QuestionComment, QuestionCommentDto>()
                .ForMember(a => a.UserName, o => o.MapFrom(x => x.CreateUser.UserName))
                .ForMember(a => a.HeadPortrait, o => o.MapFrom(x => x.CreateUser.HeadPortrait));


            CreateMap<CreateQuestionCommentsInputDto, QuestionComment>();
        }
    }
}
