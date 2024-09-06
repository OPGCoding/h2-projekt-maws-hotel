using System;

public class AppState
{
    private bool _loggedIn;
    private int _userId;
    private bool _isAdmin;

    public event Action? OnChange;

    public bool LoggedIn
    {
        get { return _loggedIn; }
        set
        {
            if (_loggedIn != value)
            {
                _loggedIn = value;
                NotifyStateChanged();
            }
        }
    }
    public int UserId
    {
        get { return _userId; }
        set
        {
            if (_userId != value)
            {
                _userId = value;
                NotifyStateChanged();
            }
        }
    }
    public bool IsAdmin
    {
        get { return _isAdmin; }
        set
        {
            if (_isAdmin != value)
            {
                _isAdmin = value;
                NotifyStateChanged();
            }
        }
    }
    public void Logout()
    {
       
        LoggedIn = false;
        UserId = 0;

        
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}



