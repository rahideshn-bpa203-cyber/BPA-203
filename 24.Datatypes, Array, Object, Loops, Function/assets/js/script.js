//1-array-de tekrarlanan ededleri silmek ve her ededin nece defe tekrarlandigini gostermek
function removeDuplicates(arr) {
    let count = {};
    let uniqueArr = [];

    for (let num of arr) {
        if (count[num]) {
            count[num] += 1;
        } else {
            count[num] = 1;
            uniqueArr.push(num); 
        }
    }

    return { uniqueArr, count };
}

let numbers = [1, 2, 2, 3, 1, 4, 2];
let result = removeDuplicates(numbers);
console.log("Unikal array:", result.uniqueArr);
console.log("Saylar:", result.count);

//2-sozun polindrome olub olmadigini yoxlamaq
//polindrome-tersine cevrilsede eyni olan soz
function isPalindrome(word) {
    let reversed = word.split("").reverse().join("");
    if (word === reversed) {
        return true;
    } else {
        return false;
    }
}

// Test
console.log(isPalindrome("radar")); // true
console.log(isPalindrome("hello")); // false
//3-ededin array-de nece elementden kicik oldugunu tapmaq
function countSmaller(arr, num) {
    let count = 0;
    for (let n of arr) {
        if (n < num) count++;
    }
    return count;
}

let arr = [3, 7, 1, 9, 4];
console.log(countSmaller(arr, 5));
//4-ededin abundant ve ya deficent oldugunu yoxlama
//abundant-ededin butun musbet bolenlerinin cemi > eded ise
//deficent cem<eded
function checkAbundantDeficent(num){
    let sum=0;
    for (let i = 0; i < n; i++) {
       if(n%i==0){
          sum += i;
       }
       if(sum>n)
        return "Abundant";
       else return "Deficient";
        
        
    }

}
console.log(checkAbundantDeficent(12));
console.log(checkAbundantDeficent(12));
//5 Array-in butun elementlerini kvadrata yukseldib yeni array qaytarmaq
function squareArray(arr) {
    return arr.map(x => x * x);
}

let nums = [1, 2, 3, 4];
console.log(squareArray(nums));