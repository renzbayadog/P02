using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

using IdigitalCafe.ViewModels; 
using IdigitalCafe.Data.Entities; 
using IdigitalCafe.Data; 
using IdigitalCafe.Data.Repositories; 
using codegen.Helpers; 
using codegen.Data.Repositories; 


namespace IdigitalCafe.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly ICategoryRepository _categoryRepository;

		public CategoriesController(IRepositoryWrapper repoWrapper)
		{
			_categoryRepository = repoWrapper.categoryRepository;
		}

		[HttpGet]
        [Route("List/Page{currPage:int}/PageSize{pageSize:int}")]
        [Route("List")]
		public async Task<IActionResult> GetAllCategory([FromQuery] CategorySearch searchInfo,int currPage = 1, int pageSize = 10)
		{
			if(!ModelState.IsValid) return BadRequest();

			List<Category> categories = await _categoryRepository.GetAllCategoryQry(searchInfo);

			// Map entity model to view model
			List<CategoryVM> categoriesVM = new List<CategoryVM>();
			
			foreach(Category category in categories)
			{
				categoriesVM.Add(new CategoryVM()
				{
					CategoryId = category.CategoryId,
					CategoryName = category.CategoryName
				});
			}

			Pagination<CategoryVM> pagination = new Pagination<CategoryVM>(categoriesVM, currPage, pageSize);

			return Ok(pagination);
		}

		[HttpPost("Add")]
		public async Task<IActionResult> PostCategory(CategoryVM category)
		{
			if (!ModelState.IsValid)
            {
                return BadRequest();
            }

			

			Category categoryToAdd = new Category()
			{
				CategoryName = category.CategoryName
			};

            _categoryRepository.Add(categoryToAdd);

            try
            {
                await _categoryRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
				return BadRequest(ex.Message.ToString());
            }

            return Ok();
		}

		[HttpPost("Update")]
		public async Task<IActionResult> PutCategory(CategoryVM category)
		{
			if (!ModelState.IsValid)
            {
                return BadRequest();
            }

			

			Category categoryToUpdate = new Category()
			{
				CategoryId = category.CategoryId,
				CategoryName = category.CategoryName
			};

            _categoryRepository.Update(categoryToUpdate);

			try
            {
                await _categoryRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
				return BadRequest(ex.Message.ToString());
            }
            return Ok();
		}

		[HttpDelete("{id}/Delete")]
        public async Task<IActionResult> DeleteCategory(int id)
		{
			Category categoryToDelete = await _categoryRepository.FindFirstAsync(m => m.CategoryId == id);
			
			if(categoryToDelete == null)
				return BadRequest("Not Found");
			
            _categoryRepository.Delete(categoryToDelete);

			try
			{
                await _categoryRepository.SaveChangesAsync();
			}
			catch (Exception ex)
            {
				return BadRequest(ex.Message.ToString());
            }
            
			return Ok();
		}

		[HttpPost("delete/bulk")]
        public async Task<IActionResult> DeleteBulk([FromBody]List<int> categories)
        {
            if (categories.Count > 0)
            {
                foreach (int category in categories)
                {
					Category categoryToDelete = await _categoryRepository.FindFirstAsync(m => m.CategoryId == category);
					_categoryRepository.Delete(categoryToDelete);
                }
				try
				{
					await _categoryRepository.SaveChangesAsync();
				}
				catch (Exception ex)
				{
					return BadRequest(ex.Message.ToString());
				}
            }
            return Ok();
        }

		#region EXPORT TO EXCEL

        [HttpGet("export/report")]
        public async Task<IActionResult> ExportCategory([FromQuery] CategorySearch searchInfo)
        {
			List<Category> categories = await _categoryRepository.GetAllCategoryQry(searchInfo);

			// Map entity model to view model
			List<CategoryVM> categoriesVM = new List<CategoryVM>();
			
			foreach(Category category in categories)
			{
				categoriesVM.Add(new CategoryVM()
				{
					CategoryId = category.CategoryId,
					CategoryName = category.CategoryName
				});
			}
 
            DataTable dt = new DataTable("Category");
            dt.Columns.Add("CategoryId", typeof(string));
						dt.Columns.Add("CategoryName", typeof(string));

            DataRow dr;

            foreach (var item in categoriesVM)
            {
                dr = dt.NewRow();

                dr[0] = item.CategoryId;
						dr[1] = item.CategoryName;

                dt.Rows.Add(dr);
            }

            var exportExcelHelperService = new ExportExcelHelper();

            var bytes = exportExcelHelperService.CreateExcelWorkBook(dt);

            var data = new ExcelData();
            data.File = bytes;

            var result = Convert.ToBase64String(data.File);

            return Ok(result);
        }
        #endregion

	}
}