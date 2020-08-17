'use strict';

class Service {
    constructor() {
        this.storageArray = [];
    }
	
    add(newObj = null) {
        if (newObj == null || newObj == undefined)
            return false;
        newObj.id = Math.random().toString(16).substr(2, 10);
        this.storageArray.push(newObj);
        return true;
    }
	
    getById(id = '') {
		this.storageArray.forEach(function(item) {
			if (item.id == id)
				return item.id;
		});
        return null;
    }
	
    getAll() {
        return this.storageArray;
    }
	
    deleteById(id = '') {
        for (let i = 0; i < this.storageArray.length; i++) {
            if (this.storageArray[i].id == id) {
                let deletedObj = this.storageArray[i];
                this.storageArray.splice(i, 1);
                return deletedObj;
            }
        }
        return null;
    }
	
    replaceById(id, newObj = null) {
        if (newObj === null)
            return false;
        for (let i = 0; i < this.storageArray.length; i++) {
            if (this.storageArray[i].id == id) {
                this.storageArray[i] = newObj;
                return true;
            }
        }
        return false;
    }
	
    updateById(id = '', newObj = null) {
        if (newObj == null || newObj == undefined)
            return false;
        for (let i = 0; i < this.storageArray.length; i++) {
            if (this.storageArray[i].id == id) {
                for (let prop in newObj) {
                    this.storageArray[i][prop] = newObj[prop];
                    return true;
                }
            }
		}
        return false;
    }
}

let storage = new Service();

let person1 = {
    'name': 'Vsevolod',
    'age': 23
};

let person2 = {
    'name': 'Nikita',
    'age': 18
};

let person3 = {
    'name': 'Mark',
	'age': 29
};

storage.add(person1);
storage.add(person2);
storage.add(person3);

console.log(storage.getAll());

console.log(storage.getById(person1.id));

console.log(storage.deleteById(person3.id));

console.log(storage.getAll());

console.log(storage.updateById(person2.id, {
    'age': 45
}));

console.log(storage.getAll());

console.log(storage.replaceById(person1.id, person3));

console.log(storage.getAll());