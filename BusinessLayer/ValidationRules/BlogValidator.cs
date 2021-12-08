using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle)
                .NotEmpty().WithMessage("Blog başlığını boş geçemezsiniz")
                .MinimumLength(45).WithMessage("Lüften 45 karakterden daha fazla veri girişi yapınız")
                .MaximumLength(150).WithMessage("Lüften 150 karakterden daha az veri girişi yapınız");

            RuleFor(x => x.BlogContent)
                .NotEmpty().WithMessage("Blog içeriğini boş geçemezsiniz")
                .MinimumLength(15).WithMessage("Lüften 15 karakterden daha fazla veri girişi yapınız")
                .MaximumLength(1000).WithMessage("Lüften 1000 karakterden daha az veri girişi yapınız");

            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog görselini boş geçemezsiniz");
            RuleFor(x => x.BlogThumbnailImage).NotEmpty().WithMessage("Blog ön görselini boş geçemezsiniz");
        }
    }
}
