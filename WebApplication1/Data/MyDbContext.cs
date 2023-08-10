using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Kind> Kinds { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new { Id = 1, Name = "Для собаки" },
                new { Id = 2, Name = "Для кота" }
            );
            modelBuilder.Entity<Kind>().HasData(
                new { Id = 1, Name = "Нашийники" },
                new { Id = 2, Name = "Шлеї" },
                new { Id = 3, Name = "Повідці" },
                new { Id = 4, Name = "Повідці-рулетки" },
                new { Id = 5, Name = "Одяг" },
                new { Id = 6, Name = "Іграшки" }
                );
            modelBuilder.Entity<Product>().HasData(
                new { ProductId = 1, Name = "\"NASA\"", Price = 109, ImgUrl = "/images/Products/1.jpg", Material = "Нейлон", Description = "Серія нейлонових нашийників WAUDOG Nylon з пластиковою пряжкою і QR паспортом виконана з якісного зносостійкого нейлону. Нашийники нової нейлонової серії прикрашені модними яскравими візерунками. Стильний дизайн нашийників серії яскраво виділить вашу собаку серед інших, а QR паспорт допоможе знайти улюбленця в разі втрати.", CategoryId = 1, KindId = 1 },
                new { ProductId = 2, Name = "\"Мілітарі\"", Price = 209, ImgUrl = "/images/Products/2.jpg", Material = "Нейлон", Description = "Серія нейлонових нашийників WAUDOG Nylon з пластиковою пряжкою і QR паспортом виконана з якісного зносостійкого нейлону. Нашийники нової нейлонової серії прикрашені модними яскравими візерунками. Стильний дизайн нашийників серії яскраво виділить вашу собаку серед інших, а QR паспорт допоможе знайти улюбленця в разі втрати.", CategoryId = 1, KindId = 1 },
                new { ProductId = 3, Name = "Classic", Price = 270, ImgUrl = "/images/Products/3.jpg", Material = "Шкіра", Description = "Серія нейлонових нашийників WAUDOG Nylon з пластиковою пряжкою і QR паспортом виконана з якісного зносостійкого нейлону. Нашийники нової нейлонової серії прикрашені модними яскравими візерунками. Стильний дизайн нашийників серії яскраво виділить вашу собаку серед інших, а QR паспорт допоможе знайти улюбленця в разі втрати.", CategoryId = 1, KindId = 1 },
                new { ProductId = 4, Name = "\"Рік та Морті\"", Price = 122, ImgUrl = "/images/Products/4.jpg", Material = "Нейлон", Description = "Серія нейлонових нашийників WAUDOG Nylon з пластиковою пряжкою і QR паспортом виконана з якісного зносостійкого нейлону. Нашийники нової нейлонової серії прикрашені модними яскравими візерунками. Стильний дизайн нашийників серії яскраво виділить вашу собаку серед інших, а QR паспорт допоможе знайти улюбленця в разі втрати.", CategoryId = 1, KindId = 1 },
                new { ProductId = 5, Name = "\"Етно синій\"", Price = 109, ImgUrl = "/images/Products/5.jpg", Material = "Нейлон", Description = "Серія нейлонових нашийників WAUDOG Nylon з пластиковою пряжкою і QR паспортом виконана з якісного зносостійкого нейлону. Нашийники нової нейлонової серії прикрашені модними яскравими візерунками. Стильний дизайн нашийників серії яскраво виділить вашу собаку серед інших, а QR паспорт допоможе знайти улюбленця в разі втрати.", CategoryId = 1, KindId = 1 },
                new { ProductId = 6, Name = "\"Кавун\"", Price = 109, ImgUrl = "/images/Products/6.jpg", Material = "Нейлон", Description = "Серія нейлонових нашийників WAUDOG Nylon з пластиковою пряжкою і QR паспортом виконана з якісного зносостійкого нейлону. Нашийники нової нейлонової серії прикрашені модними яскравими візерунками. Стильний дизайн нашийників серії яскраво виділить вашу собаку серед інших, а QR паспорт допоможе знайти улюбленця в разі втрати.", CategoryId = 1, KindId = 1 },
                new { ProductId = 7, Name = "\"Графіті\"", Price = 88, ImgUrl = "/images/Products/7.jpg", Material = "Нейлон", Description = "Чарівні нашийники WAUDOG Nylon для котів не залишать байдужими власників цих домашніх тварин. М'який і одночасно зносостійкий нейлон, вставка-гумка, бубінець для відлякування птахів і мишей, а також адресник з QR паспортом роблять нашийник не тільки красивим і зручним, але і безпечним.", CategoryId = 2, KindId = 1 },
                new { ProductId = 8, Name = "\"Вітраж\"", Price = 88, ImgUrl = "/images/Products/8.jpg", Material = "Нейлон", Description = "Чарівні нашийники WAUDOG Nylon для котів не залишать байдужими власників цих домашніх тварин. М'який і одночасно зносостійкий нейлон, вставка-гумка, бубінець для відлякування птахів і мишей, а також адресник з QR паспортом роблять нашийник не тільки красивим і зручним, але і безпечним.", CategoryId = 2, KindId = 1 },
                new { ProductId = 9, Name = "\"Авокадо\"", Price = 88, ImgUrl = "/images/Products/9.jpg", Material = "Нейлон", Description = "Чарівні нашийники WAUDOG Nylon для котів не залишать байдужими власників цих домашніх тварин. М'який і одночасно зносостійкий нейлон, вставка-гумка, бубінець для відлякування птахів і мишей, а також адресник з QR паспортом роблять нашийник не тільки красивим і зручним, але і безпечним.", CategoryId = 2, KindId = 1 },
                new { ProductId = 10, Name = "\"Colors of freedom\"", Price = 88, ImgUrl = "/images/Products/10.jpg", Material = "Нейлон", Description = "\"Colors of freedom\" — колекція, яка допоможе показати свою єдність з Україною. Патріотичні новинки — це знак ідентифікації себе та домашнього улюбленця як частини єдиної України.", CategoryId = 2, KindId = 1 },

                new { ProductId = 11, Name = "\"Диво-жінка фіолетовий\"", Price = 320, ImgUrl = "/images/Products/11.jpg", Material = "Тканина", Description = "Тепер класні логотипи і популярні супергерої всесвіту DC Comics (Бетмен, Супермен, Джокер, Харлі Квінн і інші) будуть демонструватися на яскравих м’яких шлеях WAUDOG.", CategoryId = 2, KindId = 2 },
                new { ProductId = 12, Name = "\"NASA\"", Price = 295, ImgUrl = "/images/Products/12.jpg", Material = "Тканина", Description = "Серія м'яких шлей WAUDOG з QR паспортом виконана з якісного зносостійкого нейлону.\r\nШлеї даної серії прикрашені модними яскравими візерунками.\r\nСтильний дизайн м'яких шлей виділить вашу собаку серед інших, а QR паспорт допоможе знайти улюбленця в разі втрати.", CategoryId = 2, KindId = 2 },
                new { ProductId = 13, Name = "\"Бетмен вінтаж\"", Price = 320, ImgUrl = "/images/Products/13.jpg", Material = "Тканина", Description = "Тепер класні логотипи і популярні супергерої всесвіту DC Comics (Бетмен, Супермен, Джокер, Харлі Квінн і інші) будуть демонструватися на яскравих м’яких шлеях WAUDOG.", CategoryId = 2, KindId = 2 },
                new { ProductId = 14, Name = "\"Colors of freedom\"", Price = 278, ImgUrl = "/images/Products/14.jpg", Material = "Тканина", Description = "\"Colors of freedom\" — колекція, яка допоможе показати свою єдність з Україною. Патріотичні новинки — це знак ідентифікації себе та домашнього улюбленця як частини єдиної України.", CategoryId = 2, KindId = 2 },
                new { ProductId = 15, Name = "\"Ліга Справедливості в голубому\"", Price = 320, ImgUrl = "/images/Products/15.jpg", Material = "Тканина", Description = "Стильний дизайн шлей м’якої серії яскраво виділить вашу собаку серед інших.", CategoryId = 2, KindId = 2 },
                new { ProductId = 16, Name = "\"Бетмен комікс\"", Price = 320, ImgUrl = "/images/Products/16.jpg", Material = "Тканина", Description = "Тепер класні логотипи і популярні супергерої всесвіту DC Comics (Бетмен, Супермен, Джокер, Харлі Квінн і інші) будуть демонструватися на яскравих м’яких шлеях WAUDOG.", CategoryId = 2, KindId = 2 },

                new { ProductId = 17, Name = "\"Етно зелений\"", Price = 255, ImgUrl = "/images/Products/17.jpg", Material = "Тканина", Description = "Нова серія Nylon торгової марки WAUDOG виконана з якісного зносостійкого нейлону з використанням міцної фурнітури і м'якої неопренової накладки зі світловідбиваючими елементами.", CategoryId = 1, KindId = 2 },
                new { ProductId = 18, Name = "\"Етно синій\"", Price = 255, ImgUrl = "/images/Products/18.jpg", Material = "Тканина", Description = "Нова серія Nylon торгової марки WAUDOG виконана з якісного зносостійкого нейлону з використанням міцної фурнітури і м'якої неопренової накладки зі світловідбиваючими елементами.", CategoryId = 1, KindId = 2 },
                new { ProductId = 19, Name = "\"Графіті\"", Price = 291, ImgUrl = "/images/Products/19.jpg", Material = "Нейлон", Description = "Серія нейлонових шлей WAUDOG Nylon з QR паспортом виконана з якісного зносостійкого нейлону.", CategoryId = 1, KindId = 2 },
                new { ProductId = 20, Name = "\"Рік та Морті 1\"", Price = 295, ImgUrl = "/images/Products/20.jpg", Material = "Нейлон", Description = "Культовий серіал, який дивляться в усьому світі, справжній культурний феномен і найактуальнійший тренд у фешен індустрії — \"Рік та Морті\"!\r\nЗавдяки цій супер класній ліцензії від Warner Bros, бренд WAUDOG став ще яскравішим і ексклюзивнішим. Адже це єдиний бренд у світі, який представляє продукцію із зображенням улюблених героїв кількох поколінь.", CategoryId = 1, KindId = 2 },
                new { ProductId = 21, Name = "Салатовий", Price = 230, ImgUrl = "/images/Products/21.jpg", Material = "Бавовна", Description = "Нова серія амуніції від WAUDOG з відновленої бавовни - поєднання класичного стилю і нових технологій. Стрічка, яка використовується у виробах цієї серії, виготовлена ​​з екологічно чистої сировини повторного технологічного циклу. Подібні матеріали нового покоління розробляються спеціально для того, щоб боротися з промисловим забрудненням планети.", CategoryId = 1, KindId = 2 },
                new { ProductId = 22, Name = "\"Лінія 1\"", Price = 263, ImgUrl = "/images/Products/22.jpg", Material = "Нейлон", Description = "Нова анатомічна шлея в серії WAUDOG Nylon виконана з якісного зносостійкого нейлону з використанням міцної фурнітури.\r\nІдеальна посадка і максимальний комфорт завдяки особливій формі. Шлея розроблена таким чином що при натязі повідця не відбувається здавлювання дихальних шляхів тварини.\r\nМає 2 півкільця для повідця (верхнє і нижнє), що дозволяє більш рівномірно розподілити фізичне навантаження на опорно-руховий апарат собаки.", CategoryId = 1, KindId = 2 }
                //new { ProductId = 1, Name = "Нашийник для собак WAUDOG Nylon з QR паспортом, малюнок \"NASA\", пластиковий фастекс", Price = 109, ImgUrl = "/images/Products/1.jpg", Material = "Нейлон", Description = "Серія нейлонових нашийників WAUDOG Nylon з пластиковою пряжкою і QR паспортом виконана з якісного зносостійкого нейлону. Нашийники нової нейлонової серії прикрашені модними яскравими візерунками. Стильний дизайн нашийників серії яскраво виділить вашу собаку серед інших, а QR паспорт допоможе знайти улюбленця в разі втрати.", CategoryId = 2, KindId = 1 },
                //new { ProductId = 12, Name = "Jellyfish", Price = 7, ImgUrl = "/images/Animals/jellyfish.jpg", Material = "Шкіра", Description = "Jellyfish polyp phase.", CategoryId = 2 }
                );


            modelBuilder.Entity<Comment>().HasData(
                new { Id = 1, AnimalId = 1, CommentMessage = "good animal" },
                new { Id = 2, AnimalId = 1, CommentMessage = "decent animal" },
                new { Id = 3, AnimalId = 1, CommentMessage = "not bad animal" },
                new { Id = 4, AnimalId = 2, CommentMessage = "nice animal" },
                new { Id = 5, AnimalId = 2, CommentMessage = "good lizard" },
                new { Id = 6, AnimalId = 3, CommentMessage = "pinguins are okay animal" }
                );

            //modelBuilder.Entity<Animal>().HasMany(c => c.Comments).WithOne(an => an.Animal).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Product>().HasMany(c => c.Comments).WithOne(pr => pr.Product).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
