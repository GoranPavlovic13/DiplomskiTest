using Entitites.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class ProgrammingLanguageConfiguration : IEntityTypeConfiguration<ProgrammingLanguage>
    {
        public void Configure(EntityTypeBuilder<ProgrammingLanguage> builder)
        {
            builder.HasData(
                new ProgrammingLanguage
                {
                    LanguageId = new Guid("8665c6cb-7dc0-4058-9bc7-7c65c7869d47"),
                    LanguageName = "C",
                    LanguageType = LanguageType.Procedural,
                    LanguageDescription = "Opis: C je opštepriznati proceduralni programski jezik koji je nastao u Bell Labs-u 1972. godine. Poznat je po svojoj efikasnosti, fleksibilnosti i mogućnosti direktnog pristupa hardveru.\r\nKarakteristike: Statički tipiziran, niskog nivoa apstrakcije, podržava pokazivače, omogućava direktno upravljanje memorijom.\r\nPrimeri upotrebe: Razvoj operativnih sistema, sistemske aplikacije, ugrađeni sistemi.",

                },
                new ProgrammingLanguage
                {
                    LanguageId = new Guid("48e36ba7-6216-4b19-a671-066c0f5a8e0a"),
                    LanguageName = "C++",
                    LanguageType = LanguageType.Object_Oriented,
                    LanguageDescription = "Opis: C++ je proširenje jezika C koje uvodi koncepte objektno-orijentisanog programiranja (OOP). Razvijen je kao unapređenje jezika C, omogućavajući programerima da koriste OOP paradigmu.\r\nKarakteristike: Objektno-orijentisan, podržava nasleđivanje, polimorfizam, apstrakciju i inkapsulaciju, bogata standardna biblioteka.\r\nPrimeri upotrebe: Razvoj softvera, igara, operativnih sistema, aplikacija za računarsko modelovanje."

                },
                new ProgrammingLanguage
                {
                    LanguageId = new Guid("3a9723c8-af2c-46b9-a4cd-bcb32f5a90b6"),
                    LanguageName = "C#",
                    LanguageType = LanguageType.Object_Oriented,
                    LanguageDescription = "Opis: C# je moderan, objektno-orijentisan jezik razvijen od strane Microsoft-a. Namenjen je razvoju aplikacija na platformi .NET.\r\nKarakteristike: Objektno-orijentisan, podržava garbage collection, delegati, događaji, LINQ (Language Integrated Query), Lambda izraze.\r\nPrimeri upotrebe: Razvoj Windows aplikacija, web aplikacija, igara, mobilnih aplikacija."

                },
                new ProgrammingLanguage
                {
                    LanguageId = new Guid("bcd4aaec-f236-451a-92eb-7642471c8ecc"),
                    LanguageName = "Java",
                    LanguageType = LanguageType.Object_Oriented,
                    LanguageDescription = "Opis: Java je objektno-orijentisan, platformski nezavisan jezik razvijen od strane Sun Microsystems-a (sada deo Oracle-a). Poznat je po svojoj sigurnosti i portabilnosti.\r\nKarakteristike: Objektno-orijentisan, platformski nezavisan (rad na različitim operativnim sistemima), podržava garbage collection, izuzetno popularan u razvoju web i mobilnih aplikacija.\r\nPrimeri upotrebe: Razvoj web aplikacija, mobilnih aplikacija (Android), serverskih aplikacija, finansijskih sistema."

                }
                );              
        }
    }
}
