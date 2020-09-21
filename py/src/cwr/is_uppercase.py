def is_uppercase(s):
    if s is None:
        return False

    for ch in s:
        if ch.isalpha() and not ch.isupper():
            return False
    return True


def main():
    x = ["hello", "WORLD"]
    for w in x:
        print(is_uppercase(w))


if __name__ == "__main__": main();
