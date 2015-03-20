namespace DigitalWatch.Behaviors
{
    public abstract class SingletonClockBehavior : ClockBehavior
    {
        private static object _singletonContainer;

        protected SingletonClockBehavior()
        {
            if (_singletonContainer == null)
            {
                _singletonContainer = this;
            }
        }

        public object SingletonContainer
        {
            get { return _singletonContainer; }
        }
    }
}