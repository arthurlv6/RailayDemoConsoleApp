using System;
using System.Threading.Tasks;

public static class MaybeExtension
{
    public static Maybe<K> Railway<T, K>(this Maybe<T> @this, Func<Maybe<T>, Maybe<K>> func) 
    {
        if (@this.IsFailure)
        {
            return Maybe.Fail<K>(@this.Error, @this.Exception);
        }
        return func(@this);
    }
    public static async Task<Maybe<K>> RailwayAsync<T, K>(this Maybe<T> @this, Func<Maybe<T>, Task<Maybe<K>>> func) 
    {
        if (@this.IsFailure)
        {
            return Maybe.Fail<K>(@this.Error, @this.Exception);
        }
        return await func(@this);
    }
}