import csv
import json

def get_tags(row, columns):
    tags = []
    for i in range (5, 12):
        if (row[i] == "TRUE"):
            tags.append(columns[i])
    return tags

i = 0
with open('Recipes.csv') as csv_file:
    csv_reader = csv.reader(csv_file, delimiter=',')
    line_count = 0
    columns = []
    for row in csv_reader:
        if line_count == 0:
            print(f'Column names are {", ".join(row)}')
            columns = row
            line_count += 1
        else:
            print(f'\t{row[0]} works in the {row[1]} department, and was born in {row[2]}.')
            line_count += 1
            dictionary = {
                "index": row[0],
                "name": row[1],
                "isVegetarian": row[3],
                "isVegan": row[4],
                "tags" : get_tags(row, columns)
            }
            with open("Recipes/"+ str(i) + ".json", "w") as outfile:
                json.dump(dictionary, outfile)
            i += 1
    print(f'Processed {line_count} lines.')
    
    # Data to be written

    