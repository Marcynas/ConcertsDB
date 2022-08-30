using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Newtonsoft.Json;

using Org.Ktu.Isk.P175B602.Autonuoma.Repositories;
using Org.Ktu.Isk.P175B602.Autonuoma.Models;
using Org.Ktu.Isk.P175B602.Autonuoma.ViewModels;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Controllers
{
	/// <summary>
	/// Controller for working with 'Sutartis' entity.
	/// </summary>
	public class SutartisController : Controller
	{
		/// <summary>
		/// This is invoked when either 'Index' action is requested or no action is provided.
		/// </summary>
		/// <returns>Entity list view.</returns>
		public ActionResult Index()
		{
			return View(SutartisRepo.List());
		}

		/// <summary>
		/// This is invoked when creation form is first opened in a browser.
		/// </summary>
		/// <returns>Entity creation form.</returns>
		public ActionResult Create()
		{
			var sutartisEvm = new SutartisEditVM();

			sutartisEvm.Sutartis.SutartiesData = DateTime.Now;
			sutartisEvm.Sutartis.NuomosDataLaikas = DateTime.Now;
			sutartisEvm.Sutartis.PlanuojamaGrDataLaikas = DateTime.Now;
			
			PopulateLists(sutartisEvm);

			return View(sutartisEvm);
		}


		/// <summary>
		/// This is invoked when buttons are pressed in the creation form.
		/// </summary>
		/// <param name="save">If not null, indicates that 'Save' button was clicked.</param>
		/// <param name="add">If not null, indicates that 'Add' button was clicked.</param>
		/// <param name="remove">If not null, indicates that 'Remove' button was clicked and contains in-list-id of the item to remove.</param>
		/// <param name="sutartisEvm">Entity view model filled with latest data.</param>
		/// <returns>Returns creation from view or redirets back to Index if save is successfull.</returns>
		[HttpPost]
		public ActionResult Create(int? save, int? add, int? remove, SutartisEditVM sutartisEvm)
		{
			//addition of new 'UzsakytosPaslaugos' record was requested?
			if( add != null )
			{
				//add entry for the new record
				var up =
					new SutartisEditVM.UzsakytaPaslaugaM {
						InListId =
							sutartisEvm.UzsakytosPaslaugos.Count > 0 ?
							sutartisEvm.UzsakytosPaslaugos.Max(it => it.InListId) + 1 :
							0,

						Paslauga = null,
						Kiekis = 0,
						Kaina = 0
					};
				sutartisEvm.UzsakytosPaslaugos.Add(up);

				//make sure @Html helper is not reusing old model state containing the old list
				ModelState.Clear();

				//go back to the form
				PopulateLists(sutartisEvm);
				return View(sutartisEvm);
			}

			//removal of existing 'UzsakytosPaslaugos' record was requested?
			if( remove != null )
			{
				//filter out 'UzsakytosPaslaugos' record having in-list-id the same as the given one
				sutartisEvm.UzsakytosPaslaugos =
					sutartisEvm
						.UzsakytosPaslaugos
						.Where(it => it.InListId != remove.Value)
						.ToList();

				//make sure @Html helper is not reusing old model state containing the old list
				ModelState.Clear();

				//go back to the form
				PopulateLists(sutartisEvm);
				return View(sutartisEvm);
			}

			//save of the form data was requested?
			if( save != null )
			{
				//form field validation passed?
				if( ModelState.IsValid )
				{
					//create new 'Sutartis'
					sutartisEvm.Sutartis.Nr = SutartisRepo.Insert(sutartisEvm);

					//create new 'UzsakytosPaslaugos' records
					foreach( var upVm in sutartisEvm.UzsakytosPaslaugos )
						UzsakytaPaslaugaRepo.Insert(sutartisEvm.Sutartis.Nr, upVm);

					//save success, go back to the entity list
					return RedirectToAction("Index");
				}
				//form field validation failed, go back to the form
				else
				{
					PopulateLists(sutartisEvm);
					return View(sutartisEvm);
				}
			}

			//should not reach here
			throw new Exception("Should not reach here.");
		}

		/// <summary>
		/// This is invoked when editing form is first opened in browser.
		/// </summary>
		/// <param name="id">ID of the entity to edit.</param>
		/// <returns>Editing form view.</returns>
		public ActionResult Edit(int id)
		{
			var sutartisEvm = SutartisRepo.Find(id);
			
			sutartisEvm.UzsakytosPaslaugos = UzsakytaPaslaugaRepo.List(id);			
			PopulateLists(sutartisEvm);

			return View(sutartisEvm);
		}

		/// <summary>
		/// This is invoked when buttons are pressed in the editing form.
		/// </summary>
		/// <param name="id">ID of the entity being edited</param>
		/// <param name="save">If not null, indicates that 'Save' button was clicked.</param>
		/// <param name="add">If not null, indicates that 'Add' button was clicked.</param>
		/// <param name="remove">If not null, indicates that 'Remove' button was clicked and contains in-list-id of the item to remove.</param>
		/// <param name="sutartisEvm">Entity view model filled with latest data.</param>
		/// <returns>Returns editing from view or redired back to Index if save is successfull.</returns>
		[HttpPost]
		public ActionResult Edit(int id, int? save, int? add, int? remove, SutartisEditVM sutartisEvm)
		{
			//addition of new 'UzsakytosPaslaugos' record was requested?
			if( add != null )
			{
				//add entry for the new record
				var up =
					new SutartisEditVM.UzsakytaPaslaugaM {
						InListId =
							sutartisEvm.UzsakytosPaslaugos.Count > 0 ?
							sutartisEvm.UzsakytosPaslaugos.Max(it => it.InListId) + 1 :
							0,

						Paslauga = null,
						Kiekis = 0,
						Kaina = 0
					};
				sutartisEvm.UzsakytosPaslaugos.Add(up);

				//make sure @Html helper is not reusing old model state containing the old list
				ModelState.Clear();

				//go back to the form
				PopulateLists(sutartisEvm);
				return View(sutartisEvm);
			}

			//removal of existing 'UzsakytosPaslaugos' record was requested?
			if( remove != null )
			{
				//filter out 'UzsakytosPaslaugos' record having in-list-id the same as the given one
				sutartisEvm.UzsakytosPaslaugos =
					sutartisEvm
						.UzsakytosPaslaugos
						.Where(it => it.InListId != remove.Value)
						.ToList();

				//make sure @Html helper is not reusing old model state containing the old list
				ModelState.Clear();

				//go back to the form
				PopulateLists(sutartisEvm);
				return View(sutartisEvm);
			}

			//save of the form data was requested?
			if( save != null )
			{
				//form field validation passed?
				if( ModelState.IsValid )
				{
					//update 'Sutartis'
					SutartisRepo.Update(sutartisEvm);

					//delete all old 'UzsakytosPaslaugos' records
					UzsakytaPaslaugaRepo.DeleteForSutartis(sutartisEvm.Sutartis.Nr);

					//create new 'UzsakytosPaslaugos' records
					foreach( var upVm in sutartisEvm.UzsakytosPaslaugos )
						UzsakytaPaslaugaRepo.Insert(sutartisEvm.Sutartis.Nr, upVm);

					//save success, go back to the entity list
					return RedirectToAction("Index");
				}
				//form field validation failed, go back to the form
				else
				{
					PopulateLists(sutartisEvm);
					return View(sutartisEvm);
				}
			}

			//should not reach here
			throw new Exception("Should not reach here.");
		}

		/// <summary>
		/// This is invoked when deletion form is first opened in browser.
		/// </summary>
		/// <param name="id">ID of the entity to delete.</param>
		/// <returns>Deletion form view.</returns>
		public ActionResult Delete(int id)
		{
			var sutartisEvm = SutartisRepo.Find(id);
			return View(sutartisEvm);
		}

		/// <summary>
		/// This is invoked when deletion is confirmed in deletion form
		/// </summary>
		/// <param name="id">ID of the entity to delete.</param>
		/// <returns>Deletion form view on error, redirects to Index on success.</returns>
		[HttpPost]
		public ActionResult DeleteConfirm(int id)
		{
			//load 'Sutartis'
			var sutartisEvm = SutartisRepo.Find(id);

			//'Sutartis' is in the state where deletion is permitted?
			if( sutartisEvm.Sutartis.Busena == 1 || sutartisEvm.Sutartis.Busena == 3 )
			{
				//delete the entity
				UzsakytaPaslaugaRepo.DeleteForSutartis(id);
				SutartisRepo.Delete(id);

				//redired to list form
				return RedirectToAction("Index");
			}
			//'Sutartis' is in state where deletion is not permitted
			else
			{
				//enable explanatory message and show delete form
				ViewData["deletionNotPermitted"] = true;
				return View("Delete", sutartisEvm);
			}
		}

		/// <summary>
		/// Populates select lists used to render drop down controls.
		/// </summary>
		/// <param name="sutartisEvm">'Sutartis' view model to append to.</param>
		private void PopulateLists(SutartisEditVM sutartisEvm)
		{
			//load entities for the select lists
			var automobiliai = AutomobiliaiRepo.List();
			var busenos = SutartiesBusenosRepo.List();
			var darbuotojai = DarbuotojasRepo.List();
			var klientai = KlientasRepo.List();
			var aiksteles = AikstelesRepo.List();

			//build select lists
			sutartisEvm.Lists.Automobiliai =
				automobiliai
					.Select(it =>
					{
						return
							new SelectListItem
							{
								Value = Convert.ToString(it.Id),
								Text = $"{it.ValstybinisNr} - {it.Marke} {it.Modelis}"
							};
					})
					.ToList();

			sutartisEvm.Lists.Busenos =
				busenos
					.Select(it =>
					{
						return
							new SelectListItem
							{
								Value = Convert.ToString(it.Id),
								Text = it.Name
							};
					})
					.ToList();

			sutartisEvm.Lists.Darbuotojai =
				darbuotojai
					.Select(it =>
					{
						return
							new SelectListItem
							{
								Value = it.Tabelis,
								Text = $"{it.Vardas} {it.Pavarde}"
							};
					})
					.ToList();

			sutartisEvm.Lists.Klientai =
				klientai
					.Select(it =>
					{
						return
							new SelectListItem
							{
								Value = it.AsmensKodas,
								Text = $"{it.Vardas} {it.Pavarde}"
							};
					})
					.ToList();

			sutartisEvm.Lists.Vietos =
				aiksteles
					.Select(it =>
					{
						return
							new SelectListItem
							{
								Value = Convert.ToString(it.Id),
								Text = it.Pavadinimas
							};
					})
					.ToList();

			//build select list for 'UzsakytosPaslaugos'
			{
				//initialize the destination list
				sutartisEvm.Lists.Paslaugos = new List<SelectListItem>();

				//load 'Paslaugos' to use for item groups
				var paslaugos = PaslaugaRepo.List();

				//create select list items from 'PaslauguKainos' related to each 'Paslaugos'
				foreach( var paslauga in paslaugos )
				{
					//create list item group for current 'Paslaugos' entity
					var itemGrp = new SelectListGroup() { Name = paslauga.Pavadinimas };

					//load related 'PaslauguKaina' entities
					var kainos = PaslaugosKainaRepo.LoadForPaslauga(paslauga.Id);

					//build list items for the group
					foreach( var kaina in kainos )
					{
						var sle =
							new SelectListItem {
								Value =
									//we use JSON here to make serialization/deserializaton of composite key more convenient
									JsonConvert.SerializeObject(new {
										FkPaslauga = paslauga.Id,
										GaliojaNuo = kaina.GaliojaNuo
									}),
								Text = $"{paslauga.Pavadinimas} {kaina.Kaina} EUR ({kaina.GaliojaNuo})",
								Group = itemGrp
							};
						sutartisEvm.Lists.Paslaugos.Add(sle);
					}
				}
			}
		}
	}
}