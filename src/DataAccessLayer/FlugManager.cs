using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Data.Entity;

namespace DataAccessLayer
{
    public class FlugManager
    {
        static FlugManager()
        {
            using (FlugDbContext ctx = new FlugDbContext())
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();
                 
                if (!ctx.Fluege.Any()) {

                    var f1 = new Flug { Abflugort = "Graz", Zielort = "Hamburg", Datum = DateTime.Now };
                    var f2 = new Flug { Abflugort = "Wien", Zielort = "London", Datum = DateTime.Now.AddHours(1) };
                    var f3 = new Flug { Abflugort = "Graz", Zielort = "Hamburg", Datum = DateTime.Now.AddHours(2) };
                    var f4 = new Flug { Abflugort = "Hamburg", Zielort = "Graz", Datum = DateTime.Now.AddHours(3) };
                    var f5 = new Flug { Abflugort = "Hamburg", Zielort = "Wien", Datum = DateTime.Now.AddHours(4) };
                    var f6 = new Flug { Abflugort = "Graz", Zielort = "Hamburg", Datum = DateTime.Now.AddHours(5) };
                    var f7 = new Flug { Abflugort = "Wien", Zielort = "London", Datum = DateTime.Now.AddHours(6) };

                    var b1 = new Buchung { PassagierId = 4711, Preis = 300 };
                    f1.Buchungen.Add(b1);

                    ctx.Fluege.AddRange(f1, f2, f3, f4, f5, f6, f7);
                    ctx.SaveChanges();
                }
            }

            using (FlugDbContext ctx = new FlugDbContext())
            {
                var all = ctx.Fluege.ToList();
                Debug.WriteLine(all.Count);
            }
        }

        public List<Flug> FindAll() {
            using (FlugDbContext ctx = new FlugDbContext()) {
                return ctx.Fluege.ToList();
            }
        }

        public List<Flug> FindByRoute(string from, string to) {
            using (FlugDbContext ctx = new FlugDbContext())
            {
                return ctx.Fluege.Where(f => f.Abflugort == from && f.Zielort == to).ToList();
            }
        }

        public Flug FindById(int id) {
            using (FlugDbContext ctx = new FlugDbContext())
            {
                return ctx.Fluege
                            .Include(f => f.Buchungen)
                            .Where(f => f.Id == id)
                            .FirstOrDefault();
            }
        }

        public void Create(Flug flight) {
            using (FlugDbContext ctx = new FlugDbContext())
            {
                ctx.Fluege.Add(flight);
                ctx.SaveChanges();
            }
        }

        public void Update(Flug flight)
        {
            using (FlugDbContext ctx = new FlugDbContext())
            {
                ctx.Fluege.Update(flight);
                ctx.SaveChanges();
            }
        }

    }
}
