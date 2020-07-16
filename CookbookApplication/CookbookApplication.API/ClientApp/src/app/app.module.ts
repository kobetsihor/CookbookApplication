import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { RecipeTreeComponent } from './recipe-tree.component';
import { RecipeFormComponent } from './recipe-form.component';
import { RecipeCreateComponent } from './recipe-create.component';
import { RecipeEditComponent } from './recipe-edit.component';
import { NotFoundComponent } from './not-found.component';

import { RecipeService } from './recipe.service';

const appRoutes: Routes = [
    { path: '', component: RecipeTreeComponent },
    { path: 'create', component: RecipeCreateComponent },
    { path: 'edit/:id', component: RecipeEditComponent },
    { path: '**', component: NotFoundComponent }
];

@NgModule({
    imports: [BrowserModule, FormsModule, HttpClientModule, RouterModule.forRoot(appRoutes)],
    declarations: [AppComponent, RecipeTreeComponent, RecipeCreateComponent, RecipeEditComponent,
                   RecipeFormComponent, NotFoundComponent],
    providers: [RecipeService],
    bootstrap: [AppComponent]
})
export class AppModule { }