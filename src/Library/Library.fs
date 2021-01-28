namespace Library

open System

module Caesar =

    let russianUpperLetters = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ"

    let russianLowerLetters = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя"
    let private charIndex (str: string) (ch: char) = str.IndexOf ch

    let private cipheredIndex letterIndex key letterCount =
        (letterCount + letterIndex + key) % letterCount

    let private isCharSupported (character: char): bool =
        charIndex russianLowerLetters character < 0
        || charIndex russianUpperLetters character < 0

    let private check character =
        let isLetter = Char.IsLetter character

        let isSupport = isCharSupported character

        isLetter && isSupport

    let private cipher (letter: char) (key: int) (letters: string): char =
        let letterIndex = letters.IndexOf letter

        let cipheredIndex =
            cipheredIndex letterIndex key letters.Length

        letters.Chars cipheredIndex

    let private cipherCaller (character: char) (key: int): char =
        if check character = false then
            character
        else
            let letters =
                if Char.IsUpper character then russianUpperLetters else russianLowerLetters

            let cipheredLetter = cipher character key letters
            cipheredLetter

    let encipher input key =
        // todo: add variants of russian/english/etc.
        let cipherMapper character = cipherCaller character key
        String.map cipherMapper input

    let decipher input key = encipher input -key