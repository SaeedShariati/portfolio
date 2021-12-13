﻿using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace portfolio.Models
{
    public static class SeedData
    {
        public static void SeedDatabase(ApplicationDbContext context)
        {
            //ontext.Database.Migrate();
            if (!context.Authors.Any())
            {
                context.Authors.AddRange(
                    new Author() { Username="Saeed Shariati"},
                    new Author() { Username="Dely"},
                    new Author() { Username = "Solomon"}
                    );
                context.SaveChanges();
            }
            if (!context.Posts.Any())
            {
                Comment c1 = new Comment() { Rating = 4, Text = "Not bad at all." };
                Comment c2 = new Comment() { Rating = 5, Text = "Great" };
                Comment c3 = new Comment() { Rating = 1, Text = "terrible" };

                context.Posts.AddRange(
                    new Post
                    {
                        Header = "بازی خیلی باحال",
                        Author = context.Authors.FirstOrDefault(a => a.Username == "Dely"),
                        Text = "یک بازی کامپیوتری جدید است که با سبک مبارزه ای و اکشن توسط یک استودیوی برتانیایی به نام Ninja Theory  توسعه داده شده و در 8 آگوست سال 2017 برای پلت فرم های PC و PlayStation 4 از طرف همان استودیو منتشر خواهد شود . این بازی از طرف سازندگانس یک بازی AAA مستقل خوانده شده شده است که به زودی با طرفدارن خود دیدار خواهد کرد . داستان این بازی جذاب بر اساس اساطیر قدیمی Celtic و Norse می باشد . بازیکنان در این بازی در نقش Senua و از دید او به داستان نگاه خواهند کرد چرا که او در عالم جهنی ساخته شده از تجبریات روانی خود در ذهنش به سفری خاص و منحصر به فردی پا گذاشته است . این بازی جذاب در واقع از طرف سازندگان بازی هایی همچون  Heavenly Sword , Enslaved: Odyssey to the West DmC: Devil May Cry , comes a warrior’s brutal journey into myth و madness توسعه داده شده است و به عنوان اخرین محصول این استودیو شناخته می شود و انتظار می رود مانند کار های قبل شان موفق باشد . در داستان بازی جنگجوی جوان وایکینگی از سلیک شکست خورده و در جنگ های جهنمی وایکینگ ها در جستجوی روح همسر مرده ی خود است . یکی از موارد خاص این بازی ساخته شدن آن با همکاری دانشمندان علوم اعصاب و افراد متلا به بیماری های روانی است که در این حال گیم پلی این بازی شما را به طور عمیق در ذهن آشوفته Senua فرو خواهد برد تا سختی هایی که چنین افرادی با آن دست و پنجه نرم می کنند اشنا شوید .",
                        Created = DateTime.Now,
                        Comments=new List<Comment> { c1,c2}
                    },
                    new Post
                    {
                        Header = "دنبال کار هستم",
                        Author = context.Authors.FirstOrDefault(a => a.Username == "Saeed Shariati"),
                        Text = "ConceptDraw DIAGRAM یا با نام قبلی ConceptDraw PRO یکی از پیشرفته ترین نرم افزارهای مدل سازی فرآیندهای تجاری و رسم دیاگرام و نمودار های کسب و کار می باشد که توسط شرکت CS Odessa Corp توسعه داده شده است. این نرم افزار مجموعه ای کامل از ابزارهای گرافیکی به منظور مستندسازی فرآیند های کسب و کار و رسم نمودارها و دیاگرام های مختلف ارائه می دهد که به کسب و کار های کوچک و متوسط کمک های شایانی کرده و در زمان آن ها صرفه جویی می کند. به منظور انطباق کامل نرم افزار با نیازها و کاربری های مختلف و سازگاری هر چه بیشتر آن با انواع مختلف کسب و کار ها، افزونه های مختلفی برای نرم افزار ConceptDraw DIAGRAM منتشر شده است که شرکت های مختلف می توانند بسته به نیاز و توقعات خود از آن ها استفاده کنند. هر کدام از این افزونه ها رابط کاربری نرم افزار را تا حد زیادی دگرگون کرده و یکسری قابلیت ها و امکانات اختصاصی به هسته نرم افزاری ConceptDraw DIAGRAM اضافه می کند. در زمینه دریافت خروجی و ارائه محتوا به سایر کاربران نرم افزار بسیار انعطاف پذیر بوده و همین مزیت باعث شده تا نرم افزار ConceptDraw DIAGRAM گزینه ای بسیار مناسب برای تیم های تجاری مختلف باشد. ابزارهای رسم و نمودارسازی تعبیه شده در نرم افزار بسیار ساده و سریع بوده و می تواند در سریع ترین زمان ممکن حجم عظیمی از نمودارهای مختلف را خلق کند. با استفاده از پنل سمت راست کاربران می توانند دیاگرام ها و نمودارهای حجیم را مرتب کرده و موقعیت قرار گیری و ترتیب عناصر مختلف را به راحتی تغییر دهند. با استفاده از این ابزارها کاربران می توانند نمودارها و دیاگرام های مختلفی مانند فلوچارت، نمودار جریان فرآیند، نقشه های فنی و مهندسی، اینفوگرافیک، داشبورد، پنل های مدیریتی، چارت های سازمانی و … را خلق کرده و اطلاعات خود را در قالب فرمت های مختلف ارائه دهند.",
                        Created = DateTime.Now.Subtract(new TimeSpan(100, 0, 0, 0, 0)),
                        Comments = new List<Comment> { c1, c3 }

                    });
                context.SaveChanges();

            }
        }
    }
}
