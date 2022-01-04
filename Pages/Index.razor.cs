using System.Text.Json;
using System.Threading.Tasks;
using blazor_paypal.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using blazor_paypal.Data;

namespace blazor_paypal.Pages
{

    public partial class Index : ComponentBase
    {

        [Inject]
        IJSRuntime js { get; set; }

        public SubscriptionData sub = new SubscriptionData();

        public RootSubscriber rootSub { get; set; } = new RootSubscriber();

        public static bool aprovado { get; set; } = false;

        public async Task GetInfoAsync(string id)
        {
            RootSubscriber r = new RootSubscriber();

            r = await Paypal.GetAssinatura(id);
            rootSub = r;
            
            StateHasChanged();
        }

        public async Task CancelarAsync(string id)
        {
            await Paypal.CancelarAssinatura(id);
            await Paypal.GetAssinatura(id);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender && aprovado == false)
            {
                await js.InvokeVoidAsync("init", DotNetObjectReference.Create(this), 6800);
            }

            aprovado = false;
        }

        [JSInvokable("onApprove")]
        public void OnAprove(string data)
        {
            sub = JsonSerializer.Deserialize<SubscriptionData>(data);
            System.Console.WriteLine(sub.OrderID);
            aprovado = true;
            StateHasChanged();
        }
    }
}