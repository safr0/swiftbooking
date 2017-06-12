import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const appRoutes: Routes = [
    { path: '', redirectTo: 'swiftbooking', pathMatch: 'full' },    
    { path: 'swiftbooking' }
];

export const routing: ModuleWithProviders =
    RouterModule.forRoot(appRoutes);