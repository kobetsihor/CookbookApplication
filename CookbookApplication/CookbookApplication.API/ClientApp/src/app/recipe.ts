export class Recipe {
    constructor(
        public id?: string,
        public title?: string,
        public description?: string,
        public dateCreated?: Date,
        public parentId?: string,
        public children?: Recipe[]) { }
}