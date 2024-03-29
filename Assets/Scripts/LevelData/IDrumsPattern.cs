namespace LevelData
{
    public interface IDrumsPattern
    {
        /// <summary>
        /// Quarter note duration in seconds.
        /// </summary>
        double QuarterDuration { get; }

        /// <summary>
        /// Total track duration in seconds.
        /// </summary>
        double Duration { get; }
        
        /// <summary>
        /// Beats per minute.
        /// </summary>
        double Bpm { get; }

        /// <summary>
        /// Array of beats making up the drum pattern.
        /// </summary>
        Beat[] Beats { get; }
    }
}
