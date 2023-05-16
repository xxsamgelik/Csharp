using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcApp.Models;

namespace MvcApp.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
            // добавляем начальные данные
            if (!db.Companies.Any())
            {
                Company oracle = new Company { Name = "Oracle" };
                Company google = new Company { Name = "Google" };
                Company microsoft = new Company { Name = "Microsoft" };
                Company apple = new Company { Name = "Apple" };

                Person user1 = new Person { Name = "Олег Васильев", Company = oracle, Age = 26 };
                Person user2 = new Person { Name = "Александр Овсов", Company = oracle, Age = 24 };
                Person user3 = new Person { Name = "Алексей Петров", Company = microsoft, Age = 25 };
                Person user4 = new Person { Name = "Иван Иванов", Company = microsoft, Age = 26 };
                Person user5 = new Person { Name = "Петр Андреев", Company = microsoft, Age = 23 };
                Person user6 = new Person { Name = "Василий Иванов", Company = google, Age = 23 };
                Person user7 = new Person { Name = "Олег Кузнецов", Company = google, Age = 25 };
                Person user8 = new Person { Name = "Андрей Петров", Company = apple, Age = 24 };

                db.Companies.AddRange(oracle, microsoft, google, apple);
                db.People.AddRange(user1, user2, user3, user4, user5, user6, user7, user8);
                db.SaveChanges();
            }
        }
        public async Task<IActionResult> Index(string name, int company = 0, int page = 1,
            SortState sortOrder = SortState.NameAsc)
        {
            int pageSize = 3;

            //фильтрация
            IQueryable<Person> users = db.People.Include(x => x.Company);

            if (company != 0)
            {
                users = users.Where(p => p.CompanyId == company);
            }
            if (!string.IsNullOrEmpty(name))
            {
                users = users.Where(p => p.Name!.Contains(name));
            }

            // сортировка
            switch (sortOrder)
            {
                case SortState.NameDesc:
                    users = users.OrderByDescending(s => s.Name);
                    break;
                case SortState.AgeAsc:
                    users = users.OrderBy(s => s.Age);
                    break;
                case SortState.AgeDesc:
                    users = users.OrderByDescending(s => s.Age);
                    break;
                case SortState.CompanyAsc:
                    users = users.OrderBy(s => s.Company!.Name);
                    break;
                case SortState.CompanyDesc:
                    users = users.OrderByDescending(s => s.Company!.Name);
                    break;
                default:
                    users = users.OrderBy(s => s.Name);
                    break;
            }

            // пагинация
            var count = await users.CountAsync();
            var items = await users.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            // формируем модель представления
            IndexViewModel viewModel = new IndexViewModel(
                items,
                new PageViewModel(count, page, pageSize),
                new FilterViewModel(db.Companies.ToList(), company, name),
                new SortViewModel(sortOrder)
            );
            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Person person)
        {
            db.People.Add(person);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Person person = new Person { Id = id.Value };
                db.Entry(person).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Person? person = await db.People.FirstOrDefaultAsync(p => p.Id == id);
                if (person != null) return View(person);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Person person)
        {
            db.People.Update(person);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}