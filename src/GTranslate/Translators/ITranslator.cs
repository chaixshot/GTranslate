using System.Threading;
using System.Threading.Tasks;
using GTranslate.Results;
using JetBrains.Annotations;

namespace GTranslate.Translators;

/// <summary>
/// Represents a translator.
/// </summary>
[PublicAPI]
public interface ITranslator
{
    /// <summary>
    /// Gets the name of this translator.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Translates a text to the specified language.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="toLanguage">The target language.</param>
    /// <param name="fromLanguage">The source language.</param>
    /// <param name="cancellationToken">A token used to cancel the request.</param>
    /// <returns>A task containing the translation result.</returns>
    Task<ITranslationResult> TranslateAsync(string text, string toLanguage, string? fromLanguage = null, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="TranslateAsync(string, string, string, CancellationToken)"/>
    Task<ITranslationResult> TranslateAsync(string text, ILanguage toLanguage, ILanguage? fromLanguage = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Transliterates a text to the specified language.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="toLanguage">The target language.</param>
    /// <param name="fromLanguage">The source language.</param>
    /// <param name="cancellationToken">A token used to cancel the request.</param>
    /// <returns>A task containing the transliteration result.</returns>
    Task<ITransliterationResult> TransliterateAsync(string text, string toLanguage, string? fromLanguage = null, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="TransliterateAsync(string, string, string, CancellationToken)"/>
    Task<ITransliterationResult> TransliterateAsync(string text, ILanguage toLanguage, ILanguage? fromLanguage = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Detects the language of a text.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="cancellationToken">A token used to cancel the request.</param>
    /// <returns>A task containing the detected language.</returns>
    Task<ILanguage> DetectLanguageAsync(string text, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns whether this translator supports the specified language.
    /// </summary>
    /// <param name="language">The language.</param>
    /// <returns><see langword="true"/> if the language is supported, otherwise <see langword="false"/>.</returns>
    bool IsLanguageSupported(string language);

    /// <summary>
    /// Returns whether this translator supports the specified language.
    /// </summary>
    /// <param name="language">The language.</param>
    /// <returns><see langword="true"/> if the language is supported, otherwise <see langword="false"/>.</returns>
    bool IsLanguageSupported(ILanguage language);
}