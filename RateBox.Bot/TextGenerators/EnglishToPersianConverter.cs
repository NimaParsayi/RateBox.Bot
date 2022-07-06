namespace RateBox.Bot.TextGenerators;
public static class EnglishToPersianConverter
{
    public static string ConvertRate(string rate)
    {
        rate = rate switch
        {
            $"G" => $"مناسب برای همه سنین _[{rate}]_",
            $"PG" => $"مناسب برای همه سنین (با تصمیم خانواده) _[{rate}]_",
            $"PG-13" => $"مناسب برای افراد بالای 13 سال _[{rate}]_",
            $"R" => $"مناسب برای افراد بالای 17 سال (با تصمیم خانواده) _[{rate}]_",
            $"NC-17" => $"مناسب برای افراد بزرگسال _[{rate}]_",
            $"TV-Y" => $"مناسب برای همه کودکان _[{rate}]_",
            $"TV-Y7" => $"مناسب برای کودکان بالای 7 سال _[{rate}]_",
            $"TV-G" => $"مناسب برای همه سنین _[{rate}]_",
            $"TV-PG" => $"مناسب برای همه سنین (با تصمیم خانواده) _[{rate}]_",
            $"TV-14" => $"مناسب برای افراد بالای 14 سال _[{rate}]_",
            $"TV-MA" => $"مناسب برای افراد بزرگسال _[{rate}]_",
            _ => "نامشخص"
        };

        return rate;
    }

    public static string ConvertCountries(string countries)
    {
        var splitedCountries = countries.Split(',');
        for (var i = 0; i < splitedCountries.Length; i++)
        {
            splitedCountries[i] = splitedCountries[i].ToLower().TrimStart() switch
            {
                "united states" => "ایالات متحده آمریکا",
                "greece" => "یونان",
                "germany" => "آلمان",
                "israel" => "اسراییل",
                "egypt" => "مصر",
                "south korea" => "کره جنوبی",
                "korea" => "کره جنوبی",
                "japan" => "ژاپن",
                "spain" => "اسپانیا",
                "italy" => "ایتالیا",
                "australia" => "استرالیا",
                "canada" => "کانادا",
                "united kingdom" => "انگلستان",
                "india" => "انگلستان",
                "afghanistan" => "افغانستان",
                "brazil" => "برزیل",
                "colombia" => "کلمبیا",
                "brasil" => "برزیل",
                "china" => "چین",
                "france" => "فرانسه",
                "finland" => "فنلاند",
                "georgia" => "گرجستان",
                "pakistan" => "پاکستان",
                "iraq" => "عراق",
                "syria" => "سوریه",
                "iran" => "ایران",
                "portugal" => "پرتغال",
                "russia" => "روسیه",
                "ukraine" => "اوکراین",
                "saudi arabia" => "عربستان سعودی",
                "turkey" => "ترکیه",
                "yemen" => "یمن",
                "chile" => "شیلی",
                "palestine" => "فلسطین",
                "mexico" => "مکزیک",
                "hong kong" => "هنگ کنگ",
                "vietnam" => "ویتنام",
                "switzerland" => "سوییس",
                _ => splitedCountries[i]
            };
        }

        return String.Join(" و ", splitedCountries);
    }

    public static string ConvertGenres(string genres)
    {
        var splitedGenres = genres.Split(',');
        for (var i = 0; i < splitedGenres.Length; i++)
        {
            splitedGenres[i] = splitedGenres[i].ToLower().TrimStart() switch
            {
                "action" => "اکشن",
                "comedy" => "کمدی",
                "crime" => "جنایی",
                "thriller" => "دلهره آور",
                "western" => "وسترن",
                "drama" => "درام",
                "horror" => "ترسناک",
                "fantasy" => "فانتزی",
                "mystery" => "رازآلود",
                "romance" => "عاشقانه",
                "sci-fi" => "عملی تخیلی",
                "adventure" => "ماجراجویی",
                "musical" => "موزیکال",
                "biography" => "بیوگرافی",
                "document" => "مستند",
                "sport" => "ورزشی",
                "talk show" => "تاک شو",
                "superhero" => "ابرقهرمانی",
                "noir" => "نوآر",
                _ => splitedGenres[i]
            };
        }

        return String.Join(" , ", splitedGenres);
    }
}
