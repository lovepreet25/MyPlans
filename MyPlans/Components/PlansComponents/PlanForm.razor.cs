
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MyPlansLibrary.Models;
using MyPlansServices.Exceptions;
using MyPlansServices.Interfaces;

namespace MyPlans.Components.PlansComponents
{
    public partial class PlanForm
    {
        [Inject]
        public IPlanServices PlanServices { get; set; }
        [Inject]
        NavigationManager Navigation { get; set; }

        [Parameter]
        public string Id { get; set; }

        private bool _isEditMode => Id != null;
        private PlanDetails _model = new PlanDetails();
        private bool _isBusy = false;
        private Stream _stream = null;
        private string _fileName = string.Empty;
        private string _errorMessage = string.Empty;
		protected override async Task OnInitializedAsync()
		{
			
			if (_isEditMode)
				await FetchPlanByIdAsync();
		}
		private async Task SubmitFormAsync()
        {
            _isBusy = true;
            try
            {
				FormFile formFile = null;
				if (_stream != null)
					formFile = new FormFile(_stream, _fileName);
				if (_isEditMode)
					await PlanServices.EditAsync(_model, formFile);
				else
					await PlanServices.CreateAsync(_model, formFile);

				
				Navigation.NavigateTo("/plans");
			}
            catch(APIException ex)
            {
                _errorMessage = ex.ApiErrorsResponses.Message;
            }
            catch(Exception ex)
            {
                _errorMessage = ex.Message;
            }

        }
		private async Task FetchPlanByIdAsync()
		{
			_isBusy = true;
			try
			{
				var result = await PlanServices.GetByIdAsync(Id);
				_model = result.Value;
			}
			catch (APIException ex)
			{
				_errorMessage = ex.ApiErrorsResponses.Message;
			}
			catch (Exception ex)
			{
				_errorMessage = ex.Message;
			}
			_isBusy = false;
		}
		private async Task OnChooseFileAsync(InputFileChangeEventArgs e)
        {
            _errorMessage = string.Empty;
            var file = e.File;
            if (file.Size != null)
                if(file.Size >= 2097152)
                {
                    _errorMessage = "Oops! you choose the large file";
                    return;
                }
            string[] allowedExtensions = new[] { ".jpg", ".png", ".svg" };
            string extension = Path.GetExtension(file.Name).ToLower();
            if (!allowedExtensions.Contains(extension))
            {
                _errorMessage = "Please choose a valid format of file";
                return;

            }
            using (var stream = file.OpenReadStream(2097152))
            {
                var buffer = new byte[file.Size];
                await stream.ReadAsync(buffer, 0, (int)file.Size);
                _stream = new MemoryStream(buffer);
                _stream.Position = 0;
                _fileName= file.Name;

            }
        }
    }
}
