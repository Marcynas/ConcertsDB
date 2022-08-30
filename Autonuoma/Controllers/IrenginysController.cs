using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Org.Ktu.Isk.P175B602.Autonuoma.Repositories;
using Org.Ktu.Isk.P175B602.Autonuoma.Models;
using Org.Ktu.Isk.P175B602.Autonuoma.ViewModels;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Controllers
{
    /// <summary>
	/// Controller for working with 'Irenginys' entity.
	/// </summary>

    public class IrenginysController : Controller
	{
        /// <summary>
		/// This is invoked when either 'Index' action is requested or no action is provided.
		/// </summary>
		/// <returns>Entity list view.</returns>
        public ActionResult Index()
        {
            var irenginiai = IrenginysRepo.List();
            return View(irenginiai);
        }

        /// <summary>
		/// This is invoked when creation form is first opened in browser.
		/// </summary>
		/// <returns>Creation form view.</returns>
        public ActionResult Create()
        {
            var irenginysEvm = new IrenginysEditVM();
            PopulateSelections(irenginysEvm);
            return View(irenginysEvm);
        }

        /// <summary>
		/// This is invoked when buttons are pressed in the creation form.
		/// </summary>
		/// <param name="modelisEvm">Entity model filled with latest data.</param>
		/// <returns>Returns creation from view or redirects back to Index if save is successfull.</returns>
		[HttpPost]
        public ActionResult Create(IrenginysEditVM irenginysEvm)
        {
            //form field validation passed?
            if (ModelState.IsValid)
            {
                IrenginysRepo.Insert(irenginysEvm);

                //save success, go back to the entity list
                return RedirectToAction("Index");
            }

            //form field validation failed, go back to the form
            PopulateSelections(irenginysEvm);
            return View(irenginysEvm);
        }

		/// <summary>
		/// This is invoked when editing form is first opened in browser.
		/// </summary>
		/// <param name="id">ID of the entity to edit.</param>
		/// <returns>Editing form view.</returns>
        public ActionResult Edit(int id)
        {
            var irenginysEvm = IrenginysRepo.Find(id);
            PopulateSelections(irenginysEvm);

            return View(irenginysEvm);
        }

        /// <summary>
		/// This is invoked when buttons are pressed in the editing form.
		/// </summary>
		/// <param name="id">ID of the entity being edited</param>
		/// <param name="autoEvm">Entity model filled with latest data.</param>
		/// <returns>Returns editing from view or redirects back to Index if save is successfull.</returns>
		[HttpPost]
        public ActionResult Edit(int id, IrenginysEditVM irenginysEvm)
        {
            //form field validation passed?
            if (ModelState.IsValid)
            {
                IrenginysRepo.Update(irenginysEvm);

                //save success, go back to the entity list
                return RedirectToAction("Index");
            }

            //form field validation failed, go back to the form
            PopulateSelections(irenginysEvm);
            return View(irenginysEvm);
        }

        /// </summary>
		/// <param name="id">ID of the entity to delete.</param>
		/// <returns>Deletion form view.</returns>
        public ActionResult Delete(int id)
        {
            var irenginysLvm = IrenginysRepo.FindForDeletion(id);
            return View(irenginysLvm);
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
				IrenginysRepo.Delete(id);

				//deletion success, redired to list form
				return RedirectToAction("Index");
			}
			//entity in use, deletion not permitted
			catch( MySql.Data.MySqlClient.MySqlException )
			{
				//enable explanatory message and show delete form
				ViewData["deletionNotPermitted"] = true;

				var modelisLvm = IrenginysRepo.FindForDeletion(id);

				return View("Delete", modelisLvm);
			}
        }

        /// <summary>
		/// Populates select lists used to render drop down controls.
		/// </summary>
		/// <param name="irenginysEditVM">'Irenginys' view model to append to.</param>
		public void PopulateSelections(IrenginysEditVM irenginysEditVM)
		{
			//load entities for the select lists
			var IRENGINIO_TIPAI = IrenginioTipasRepo.List();

            //build select lists
			irenginysEditVM.Lists.IrenginioTipai =
				IRENGINIO_TIPAI.Select(it => {
					return
						new SelectListItem() {
							Value = it.Id.ToString(),
							Text = it.Pavadinimas + " (" + it.Tipas + ")",
						};
				})
				.ToList();
		}
    }
}