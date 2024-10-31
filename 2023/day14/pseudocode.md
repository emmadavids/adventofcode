-calculate total hash value on first 2 chars
-the above calculation can be the key (hash value) in a dictionary, the value will be a tuple containing the first 2 chars & focal length
-check if third char is - or =, if it is - then go to relevant box and remove the lens with that label, if it is = then one of the following sitches will apply:
-if the first 2 chars are in the dictionary, remove the previous tuple from the dictionary replace at the same index. 
-if they arent in the dictionary push to the end
-final sum will be dictionary will be box number * 1 (incrementing for every tuple in list) * focal length


if it is in there, take it out, if is in there, replace it