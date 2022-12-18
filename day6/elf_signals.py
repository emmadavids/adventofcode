
with open('signalcode.txt', 'r') as f:
    signals = f.read()

sent_signals = []
seen = []

for char in range(0, len(signals)): 
    seen = signals[char:char+14] 
    no_repeated_chars = len(set(seen)) == len(seen)
    if no_repeated_chars:
        print(seen)
        str1 = ""
        print(signals.index(str1.join(seen)))
        index = signals.index(str1.join(seen)) + 14
        sent_signals.append(index)
        seen = ""

print(sent_signals)