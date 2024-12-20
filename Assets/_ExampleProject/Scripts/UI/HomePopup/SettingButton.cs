using ExampleProject.Manager;
using ExampleProject.UI.BaseUI;
using ExampleProject.UI.BaseUI.BasePopup;

namespace ExampleProject.UI.HomePopup
{
    public class SettingButton : BaseButton
    {
        #region Fields



        #endregion

        #region Properties



        #endregion

        #region LifeCycle   



        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        protected override void ListenerMethod()
        {
            base.ListenerMethod();
            UIManager.Instance.GetPopup(PopupId.SettingPopup).SetOnStartHide(() =>
            {

            }).Show();
        }

        #endregion      
    }
}