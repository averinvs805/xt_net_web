'use strict'

let testString = "У попа была собака";
let punctuation = ['?', '!', ':', ';', ',', '.', ' ', '\n', '\t'];
let deletionArray = [];

let resultString = testString;
let lcString = testString.toLowerCase();
let words = splitToWords(lcString, punctuation);

for (let i = 0; i < words.length; i++) {
	for (let j = 0; j < words[i].length; j++) {
		if (words[i].includes(words[i][j], j + 1))
			deletionArray.push(words[i][j]);
	}
}

deletionArray.forEach(function (item) {
	resultString = resultString.split(item).join("")
});

console.log(resultString);

function splitToWords(str, separators) {
	separators.forEach(function (item) {
		str = str.split(item).join(' ');
	});
    str = str.split(' ');
    return str;
}