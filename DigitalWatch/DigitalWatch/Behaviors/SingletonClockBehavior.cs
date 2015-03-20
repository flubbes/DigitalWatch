namespace DigitalWatch.Behaviors
{
    /// <summary>
    /// The base class for all behaviors that must be unique in one instance of the program
    /// </summary>
    public abstract class SingletonClockBehavior : ClockBehavior
    {
        private static object _singletonContainer;

        /// <summary>
        /// initializes a new instance of a SingletonClockBehavior
        /// </summary>
        protected SingletonClockBehavior()
        {
            if (_singletonContainer == null)
            {
                _singletonContainer = this;
            }
        }

        /// <summary>
        /// A workaround to make singletons check their own existence
        /// </summary>
        public object SingletonContainer
        {
            get { return _singletonContainer; }
        }
    }
}