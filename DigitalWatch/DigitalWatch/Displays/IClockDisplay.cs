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

        /// <summary>
        /// Triggers the update.
        /// </summary>
        /// <param name="displayData">The display data.</param>
        void TriggerUpdate(string displayData);

        /// <summary>
        /// Triggers the switch light on.
        /// </summary>
        void TriggerSwitchLightOn();

        /// <summary>
        /// Triggers the switch light off.
        /// </summary>
        void TriggerSwitchLightOff();
    }
}