// reduce()

sum values of an array:
myArray = [1, 2, 3, 4];
output = myArray.reduce((acc, val, i, arr) =>
    {
        console.log(
            'acc:', acc,
            'val:', val,
            'index:', i,
            'arr:', arr);
        return acc + val;
    }, 100);
console.log('output:', output);

flatten array of arrays:
myData = [[8, 6], [5, 4, 3], [2]];
output = myData.reduce((acc, val) => {
    return acc.concat(val);
}, []);

console.log(output);


get the average of elements in array:
myTransactions = [12.50, 3.84, 2.97];
average = myTransactions.reduce((acc, val, i, arr) => {
    acc += val;
    if(i === arr.length - 1){
        return acc/arr.length;
    }
    else{
        return acc;
    }
});

console.log('average:', average);
