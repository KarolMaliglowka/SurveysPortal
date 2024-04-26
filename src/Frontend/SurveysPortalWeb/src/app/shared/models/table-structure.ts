export type TableStructure<T> = {
    field: keyof T,
    header: string,
    order?: number
};
