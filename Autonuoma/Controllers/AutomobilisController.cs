using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Org.Ktu.Isk.P175B602.Autonuoma.Repositories;
using Org.Ktu.Isk.P175B602.Autonuoma.Models;
using Org.Ktu.Isk.P175B602.Autonuoma.ViewModels;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Controllers
{
	/// <summary>
	/// Controller for working with 'Automobilis' entity.
	/// </summary>
	public class AutomobilisController : Controller
	{
		/// <summary>
		/// This is invoked when either 'Index' action is requested or no action is provided.
		/// </summary>
		/// <returns>Entity list view.</returns>
		public ActionResult Index()
		{
			return View(AutomobiliaiRepo.List());
		}

		/// <summary>
		/// This is invoked when creation form is first opened in browser.
		/// </summary>
		/// <returns>Creation form view.</returns>
		public ActionResult Create()
		{
			var autoEvm = new AutoEditVM();
			PopulateSelections(autoEvm);

			return View(autoEvm);
		}

		/// <summary>
		/// This is invoked when buttons are pressed in the creation form.
		/// </summary>
		/// <param name="autoEvm">Entity model filled with latest data.</param>
		/// <returns>Returns creation from view or redirects back to Index if save is successfull.</returns>
		[HttpPost]
		public ActionResult Create(AutoEditVM autoEvm)
		{
			//form field validation passed?
			if( ModelState.IsValid )
			{
				AutomobiliaiRepo.Insert(autoEvm);

				//save success, go back to the entity list
				return RedirectToAction("Index");
			}
			
			//form field validation failed, go back to the form
			PopulateSelections(autoEvm);
			return View(autoEvm);
		}

		/// <summary>
		/// This is invoked when editing form is first opened in browser.
		/// </summary>
		/// <param name="id">ID of the entity to edit.</param>
		/// <returns>Editing form view.</returns>
		public ActionResult Edit(int id)
		{
			var autoEevm = AutomobiliaiRepo.Find(id);
			PopulateSelections(autoEevm);

			return View(autoEevm);
		}

		/// <summary>
		/// This is invoked when buttons are pressed in the editing form.
		/// </summary>
		/// <param name="id">ID of the entity being edited</param>		
		/// <param name="autoEvm">Entity model filled with latest data.</param>
		/// <returns>Returns editing from view or redirects back to Index if save is successfull.</returns>
		[HttpPost]
		public ActionResult Edit(int id, AutoEditVM autoEvm)
		{
			//form field validation passed?
			if (ModelState.IsValid)
			{
				AutomobiliaiRepo.Update(autoEvm);

				//save success, go back to the entity list
				return RedirectToAction("Index");
			}

			//form field validation failed, go back to the form
			PopulateSelections(autoEvm);
			return View(autoEvm);
		}

		/// </summary>
		/// <param name="id">ID of the entity to delete.</param>
		/// <returns>Deletion form view.</returns>
		public ActionResult Delete(int id)
		{
			var autoEvm = AutomobiliaiRepo.Find(id);
			return View(autoEvm);
		}

		/// <summary>
		/// This is invoked when deletion is confirmed in deletion form
		/// </summary>
		/// <param name="id">ID of the entity to delete.</param>
		/// <returns>Deletion form view on error, redirects to Index on success.</returns>
		[HttpPost]
		public ActionResult DeleteConfirm(int id)
		{
			//try deleting, this will fail if foreign key constraint fails
			try 
			{
				AutomobiliaiRepo.Delete(id);

				//deletion success, redired to list form
				return RedirectToAction("Index");
			}
			//entity in use, deletion not permitted
			catch( MySql.Data.MySqlClient.MySqlException )
			{
				//enable explanatory message and show delete form
				ViewData["deletionNotPermitted"] = true;

				var autoEvm = AutomobiliaiRepo.Find(id);
				PopulateSelections(autoEvm);

				return View("Delete", autoEvm);
			}
		}

		/// <summary>
		/// Populates select lists used to render drop down controls.
		/// </summary>
		/// <param name="autoEvm">'Automobilis' view model to append to.</param>
		public void PopulateSelections(AutoEditVM autoEvm)
		{
			//load entities for the select lists
			var pavaruDezes = PavaruDezeRepo.List();
			var kebulai = KebulasRepo.List();
			var degaluTipai = DegaluTipasRepo.List();
			var bagazai = BagazasRepo.List();
			var busenos = AutoBusenaRepo.List();

			//build select lists
			autoEvm.Lists.PavaruDezes = 
				pavaruDezes.Select(it => {
					return
						new SelectListItem() { 
							Value = Convert.ToString(it.Id), 
							Text = it.Pavadinimas 
						};
				})
				.ToList();

			autoEvm.Lists.Kebulai = 
				kebulai.Select(it => {
					return
						new SelectListItem() { 
							Value = Convert.ToString(it.Id), 
							Text = it.Pavadinimas 
						};
				})
				.ToList();

			autoEvm.Lists.DegaluTipai = 
				degaluTipai.Select(it => {
					return
						new SelectListItem() { 
							Value = Convert.ToString(it.Id), 
							Text = it.Pavadinimas 
						};
				})
				.ToList();
			
			autoEvm.Lists.Bagazai = 
				bagazai.Select(it => {
					return
						new SelectListItem() { 
							Value = Convert.ToString(it.Id), 
							Text = it.Pavadinimas 
						};
				})
				.ToList();

			autoEvm.Lists.Busenos = 
				busenos.Select(it => {
					return
						new SelectListItem() { 
							Value = Convert.ToString(it.Id), 
							Text = it.Pavadinimas 
						};
				})
				.ToList();

			//build select list for 'Modeliai'
			{
				//initialize the destination list
				autoEvm.Lists.Modeliai = new List<SelectListItem>();

				//load 'Marke' entities to use for item groups
				var markes = MarkeRepo.List();

				//create select list items from 'Modelis' related to each 'Marke'
				foreach( var marke in markes )
				{
					//create list item group for current 'Marke' entity
					var itemGrp = new SelectListGroup() { Name = marke.Pavadinimas };

					//load related 'Modelis' entities
					var modeliai = ModelisRepo.ListForMarke(marke.Id);

					//build list items for the group
					foreach( var modelis in modeliai )
					{
						var sle =
							new SelectListItem {
								Value = Convert.ToString(modelis.Id),
								Text = modelis.Pavadinimas,
								Group = itemGrp
							};
						autoEvm.Lists.Modeliai.Add(sle);
					}
				}
			}
		}
	}
}
