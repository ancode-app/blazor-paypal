using System.Text.Json;
using System.Threading.Tasks;
using blazor_paypal.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace blazor_paypal.Pages
{

    public partial class Index : ComponentBase
    {
        [Inject]
        IJSRuntime js { get; set; }

        public static bool aprovado { get; set; } = false;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender && aprovado == false)
            {
                await js.InvokeVoidAsync("init", DotNetObjectReference.Create(this), 6800);
            }

            aprovado = false;
        }

        [JSInvokable("onApprove")]
        public void OnAprove()
        {
            aprovado = true;
            StateHasChanged();
        }
    }
}