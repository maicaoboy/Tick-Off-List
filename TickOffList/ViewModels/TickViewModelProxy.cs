using TickOffList.Services;

namespace TickOffList.ViewModels;

/* ==============================================================================
* 创建人：李宏彬
* 创建时间：2022-11-18
* @version 1.0
* ==============================================================================*/

[QueryProperty(nameof(Args), "parameter")]
public class TickViewModelProxy : TickViewModel{
    public TickViewModelProxy(IHabitStorage habitStorage, IRootNavigationService rootNavigationService, IAlertService alertService) : base(habitStorage, rootNavigationService,alertService ) { }
}