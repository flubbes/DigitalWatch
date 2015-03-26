using DigitalWatch.Displays.ToggleLightEvent;
using DigitalWatch.Displays.UpdateEvent;

namespace DigitalWatch.Displays
{
    /// <summary>
    /// The interface from which all the displays must be derived
    /// </summary>
    public interface IClockDisplay
    {
        event UpdateEventHandler Update;

        event SwitchLightOnEventHandler SwitchLightOn;

        event SwitchLightOffEventHandler SwitchLightOff;

        void TriggerUpdate(string displayData);

        void TriggerSwitchLightOn();

        void TriggerSwitchLightOff();
    }
}