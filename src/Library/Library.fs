namespace Library

open System

module Shared =
    let russianUpperLetters = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ"

    let russianLowerLetters = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя"
    
    let isCharSupported (character: char): bool =
        russianLowerLetters.IndexOf character < 0
        || russianUpperLetters.IndexOf character < 0

    let internal check character =
        let isLetter = Char.IsLetter character

        let isSupport = isCharSupported character

        isLetter && isSupport

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
            let letters =
                if Char.IsUpper character then Shared.russianUpperLetters else Shared.russianLowerLetters
            cipher character key letters

    let encrypt input key =
        // todo: add variants of russian/english/etc.
        let cipherMapper character = cipherCaller character key
        String.map cipherMapper input

    let decrypt input key = encrypt input -key

module Vigenere =
    
    let private replicateKey (key: string) (factor: int) (part: int) =
        if part = 0 then String.replicate factor key
        else
            String.replicate factor key + key.Substring (0, part)
            
    let private fullKey (key: string) (inputLength: int): string =
        if key.Length > inputLength then key.Substring (0, inputLength)
        else
            let keyLength = key.Length
            let factor = int inputLength / keyLength
            let part = inputLength % keyLength
            replicateKey key factor part
    
    let private vigenereCaller (character: char) (fullKey: string) (isEncrypting: bool)=
        if Shared.check character = false then
            character
        else
            let letters =
                if Char.IsUpper character then Shared.russianUpperLetters else Shared.russianLowerLetters
            let encryptingStep = if isEncrypting = true then 1 else -1
             // todo: finish algorythm
            'a'
    
    let encrypt (input: string) key =
        let vigenereMapper character = vigenereCaller character key true
        String.map vigenereMapper input
    
    let decrypt (input: string) key =
        let vigenereMapper character = vigenereCaller character key false
        String.map vigenereMapper input