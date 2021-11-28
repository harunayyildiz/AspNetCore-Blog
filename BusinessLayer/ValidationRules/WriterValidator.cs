using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriteName)
                .NotEmpty().WithMessage("Adı ve soyadı boş geçilemez")
                .MinimumLength(4).WithMessage("Adı ve soyadı geçersiz")
                .MaximumLength(25).WithMessage("Lüfren en fazla 25 karakterlik veri girişi yapınız.");

            RuleFor(x => x.WriterMail)
                .NotEmpty().WithMessage("Mail adresi boş geçilemez")
                .EmailAddress().WithMessage("Geçersiz mail adresi");

            RuleFor(x => x.WriterPassword)
                .NotEmpty().WithMessage("Şifreniz boş geçilemez")
                .MinimumLength(8).WithMessage("Şifreniz en az 8 karakter olmalıdır.")
                .MaximumLength(16).WithMessage("Şifreniz en fazla 16 karakter olmalıdır.")
                .Matches(@"[A-Z]+").WithMessage("Şifreniz en az bir büyük harf içermelidir.")
                .Matches(@"[a-z]+").WithMessage("Şifreniz en az bir küçük harf içermelidir.")
                .Matches(@"[0-9]+").WithMessage("Şifreniz en az bir rakam içermelidir.");

            RuleFor(x => x.WriterRePassword).Equal(x => x.WriterPassword)
                .WithMessage("Şifreleriniz eşleşmemektedir")
                .NotEmpty().WithMessage("Şifre tekrarı boş geçilemez")
                .MinimumLength(8).WithMessage("Şifre tekrarı en az 8 karakter olmalıdır.")
                .MaximumLength(16).WithMessage("Şifre tekrarı en fazla 16 karakter olmalıdır.")
                .Matches(@"[A-Z]+").WithMessage("Şifre tekrarı en az bir büyük harf içermelidir.")
                .Matches(@"[a-z]+").WithMessage("Şifre tekrarı en az bir küçük harf içermelidir.")
                .Matches(@"[0-9]+").WithMessage("Şifre tekrarı en az bir rakam içermelidir.");


            //Equals() methodları'nın ikisi de farklı 2 değeri karşılaştırmak için kullanılır.
            //RuleFor(x => x.WriterImage).NotEmpty().WithMessage("Lütfen profil fotoğrafınızı seçiniz");

        }
    }
}
