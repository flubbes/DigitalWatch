namespace DigitalWatch.Behaviors
{
    /// <summary>
    /// The base class for all behaviors that must be unique in one instance of the program
    /// </summary>
    public abstract class SingletonClockBehavior<T> : ClockBehavior where T : new()
    {
        private static readonly T SingletonInstance = new T();

        /// <summary>
        /// A workaround to make singletons check their own existence
        /// </summary>
        public T Instance
        {
            get { return SingletonInstance; }
        }
    }
}