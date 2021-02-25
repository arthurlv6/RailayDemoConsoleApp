using System;
using System.Threading.Tasks;

public static class ComExtensions
{
    public static T Action<T>(this T @this, Action<T> action)
    {
        action(@this);

        return @this;
    }
    public static async Task<T> ActionAsync<T>(this T @this, Func<T,Task<T>> action)
    {
        await action(@this);
        return @this;
    }
    public static T Map<S, T>(this S @this, Func<S, T> func)
    {
        return func(@this);
    }
    public static async Task<T> MapAsync<S, T>(this S @this, Func<S, Task<T>> func)
    {
        return await func(@this);
    }
    // better not to use the below three method in the logic layer.
    public static Maybe<T> TryGetMaybeObject<S,T>(this S @this, Func<S, T> func)
    {
        try
        {
            return Maybe.Ok(func(@this));
        }
        catch (Exception ex)
        {
            return Maybe.Fail<T>(ex.Message);
        }
    }
    public static async Task<Maybe<T>> TryGetMaybeObjectAsync<S, T>(this S @this, Func<S, Task<T>> func)
    {
        try
        {
            return Maybe.Ok(await func(@this));
        }
        catch (Exception ex)
        {
            return Maybe.Fail<T>(ex.Message);
        }
    }
    public static async Task<Maybe> TryGetMaybeObjectAsync<S>(this S @this, Func<S, Task> func)
    {
        try
        {
            await func(@this);
            return Maybe.Ok();
        }
        catch (Exception ex)
        {
            return Maybe.Fail(ex.Message);
        }
    }
}

