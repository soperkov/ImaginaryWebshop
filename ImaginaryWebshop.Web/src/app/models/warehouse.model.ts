export interface WarehouseCreateDto {
    productId: string;
    stockQuantity: number;
    position: string;
}

export interface WarehouseUpdateDto {
    stockQuantity?: number;
    position?: string;
}

export interface WarehouseDetailsDto {
    id: string;
    productId: string;
    stockQuantity: number;
    position: string;
}