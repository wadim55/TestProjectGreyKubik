using System;

public static class GameEvent

{

    public static Action<string> Kub;
    public static Action<int> AudioButton;
    public static Action <float> _volume;

    public static void Sobitie(string _tagPocket)
    {
        Kub?.Invoke(_tagPocket);
    }
    public static void AudioSobitie(int _whoCall)
    {
        AudioButton?.Invoke(_whoCall);
    }

    public static void Changevolume(float volume)
    {
        _volume?.Invoke(volume);
    }
    
}
