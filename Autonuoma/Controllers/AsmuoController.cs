using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Org.Ktu.Isk.P175B602.Autonuoma.Repositories;
using Org.Ktu.Isk.P175B602.Autonuoma.Models;
using Org.Ktu.Isk.P175B602.Autonuoma.ViewModels;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Controllers
{
	/// <summary>
	/// Controller for working with 'Asmuo' entity.
	/// </summary>
	public class AsmuoController : Controller
	{

		/// <summary>
		/// This is invoked when either 'Index' action is requested or no action is provided.
		/// </summary>
		/// <returns>Entity list view.</returns>
		public ActionResult Index()
		{
			var asmenys = AsmuoRepo.List();
			return View(asmenys);
		}

		/// <summary>
		/// This is invoked when creation form is first opened in browser.
		/// </summary>
		/// <returns>Creation form view.</returns>
		public ActionResult Create()
		{
			var AsmuoEvm = new AsmuoEditVM();
			PopulateSelections(AsmuoEvm);
			return View(AsmuoEvm);
		}

		/// <summary>
		/// This is invoked when buttons are pressed in the creation form.
		/// </summary>
		/// <param name="modelisEvm">Entity model filled with latest data.</param>
		/// <returns>Returns creation from view or redirects back to Index if save is successfull.</returns>
		[HttpPost]
		public ActionResult Create(AsmuoEditVM modelisEvm)
		{
			//form field validation passed?
			if( ModelState.IsValid )
			{
				AsmuoRepo.Insert(modelisEvm);

				//save success, go back to the entity list
				return RedirectToAction("Index");
			}

			//form field validation failed, go back to the form
			PopulateSelections(modelisEvm);
			return View(modelisEvm);
		}

		/// <summary>
		/// This is invoked when editing form is first opened in browser.
		/// </summary>
		/// <param name="id">ID of the entity to edit.</param>
		/// <returns>Editing form view.</returns>
		public ActionResult Edit(int id)
		{
			var modelisEvm = AsmuoRepo.Find(id);
			PopulateSelections(modelisEvm);

			return View(modelisEvm);
		}

		/// <summary>
		/// This is invoked when buttons are pressed in the editing form.
		/// </summary>
		/// <param name="id">ID of the entity being edited</param>
		/// <param name="autoEvm">Entity model filled with latest data.</param>
		/// <returns>Returns editing from view or redirects back to Index if save is successfull.</returns>
		[HttpPost]
		public ActionResult Edit(int id, AsmuoEditVM modelisEvm)
		{
			//form field validation passed?
			if( ModelState.IsValid )
			{
				AsmuoRepo.Update(modelisEvm);

				//save success, go back to the entity list
				return RedirectToAction("Index");
			}

			//form field validation failed, go back to the form
			PopulateSelections(modelisEvm);
			return View(modelisEvm);
		}

		/// </summary>
		/// <param name="id">ID of the entity to delete.</param>
		/// <returns>Deletion form view.</returns>
		public ActionResult Delete(int id)
		{
			var modelisLvm = AsmuoRepo.FindForDeletion(id);
			return View(modelisLvm);
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
				AsmuoRepo.Delete(id);

				//deletion success, redired to list form
				return RedirectToAction("Index");
			}
			//entity in use, deletion not permitted
			catch( MySql.Data.MySqlClient.MySqlException )
			{
				//enable explanatory message and show delete form
				ViewData["deletionNotPermitted"] = true;

				var modelisLvm = AsmuoRepo.FindForDeletion(id);

				return View("Delete", modelisLvm);
			}
		}

		/// <summary>
		/// Populates select lists used to render drop down controls.
		/// </summary>
		/// <param name="modelisEvm">'Automobilis' view model to append to.</param>
		public void PopulateSelections(AsmuoEditVM modelisEvm)
		{
			//load entities for the select lists
			var markes = LytisRepo.List();

			//build select lists
			modelisEvm.Lists.Asmenys =
				markes.Select(it => {
					return
						new SelectListItem() {
							Value = Convert.ToString(it.Id),
							Text = it.Pavadinimas
						};
				})
				.ToList();
		}
	}
}
