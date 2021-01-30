namespace Library

open System

module Shared =
    let russianUpperLetters = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ"

    let russianLowerLetters = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя"

    let isCharSupported (character: char): bool =
        russianLowerLetters.IndexOf character < 0
        || russianUpperLetters.IndexOf character < 0

    let check character =
        let isLetter = Char.IsLetter character

        let isSupport = isCharSupported character

        isLetter && isSupport

    let internal letters (letter: char) =
        if Char.IsUpper letter then russianUpperLetters else russianLowerLetters

module Caesar =

    let private cipheredIndex letterIndex key letterCount =
        (letterCount + letterIndex + key) % letterCount

    let private cipher (letter: char) (key: int) (letters: string): char =
        let letterIndex = letters.IndexOf letter

        let cipheredIndex =
            cipheredIndex letterIndex key letters.Length

        letters.Chars cipheredIndex

    let private cipherCaller (character: char) (key: int): char =
        if Shared.check character = false then
            character
        else
            let letters = Shared.letters character
            cipher character key letters

    let encrypt input key =
        // todo: add variants of russian/english/etc.
        let cipherMapper character = cipherCaller character key
        String.map cipherMapper input

    let decrypt input key = encrypt input -key

module Vigenere =

    let replicateKey (key: string) (factor: int) (part: int) =
        String.replicate factor key
        + key.Substring(0, part)

    let fullKey (key: string) (inputLength: int): string =
        if key.Length > inputLength then
            key.Substring(0, inputLength)
        else
            let keyLength = key.Length
            let factor = int inputLength / keyLength
            let part = inputLength % keyLength
            replicateKey key factor part