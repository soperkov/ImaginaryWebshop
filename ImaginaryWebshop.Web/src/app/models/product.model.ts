export interface ProductCreateDto {
    name: string;
    description: string;
    price: number;
    category: string;
}

export interface ProductUpdateDto {
    name?: string;
    description?: string;
    price?: number;
    category?: string;
}

export interface ProductDetailsDto {
    id: string;
    name: string;
    description: string;
    price: number;
    category: string;
}