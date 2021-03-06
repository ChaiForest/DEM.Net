﻿using BitMiracle.LibTiff.Classic;
using System.Collections.Generic;

namespace DEM.Net.Lib.Services
{
    public interface IGeoTiffService
    {
        FileMetadata ParseMetadata(GeoTiff tiff, string tiffPath);
        FileMetadata ParseMetadata(string fileName);
        List<FileMetadata> LoadManifestMetadata(string tiffPath);

        void DumpTiffTags(Tiff tiff);


        /// <summary>
        /// Generate metadata files for fast in-memory indexing
        /// </summary>
        /// <param name="directoryPath">GeoTIFF files directory</param>
        /// <param name="generateBitmaps">If true, bitmaps with height map will be generated (heavy memory usage and waaaay slower)</param>
        /// <param name="force">If true, force regeneration of all files. If false, only missing files will be generated.</param>
        void GenerateDirectoryMetadata(string directoryPath, bool generateBitmaps, bool force);

        /// <summary>
        /// Compare LST file and local directory and generates a report indicatif which files are dowloaded
        /// and which ones are missing.
        /// </summary>
        /// <param name="directoryPath">GeoTIFF local directory</param>
        /// <param name="urlToLstFile">LST file from server</param>
        /// <param name="remoteFileExtension">Filter for remote files (ex. .hgt.zip instead of .hgt)</param>
        /// <param name="newRemoteFileExtension">Set if remote LST does not show files with extension. (example with .hgt files listed and .SRTMGL3.hgt.zip on the server)</param>
        /// <returns></returns>
        string GenerateReportAsString(string directoryPath, string urlToLstFile, string remoteFileExtension, string newRemoteFileExtension = null);

        /// <summary>
        /// Compare LST file and local directory and generates dictionary with key : remoteFile and value = true if file is present and false if it is not downloaded
        /// </summary>
        /// <param name="directoryPath">GeoTIFF local directory</param>
        /// <param name="urlToLstFile">LST file from server</param>
        /// <param name="remoteFileExtension">Filter for remote files (ex. .hgt.zip instead of .hgt)</param>
        /// <param name="newRemoteFileExtension">Set if remote LST does not show files with extension. (example with .hgt files listed and .SRTMGL3.hgt.zip on the server)</param>
        /// <returns></returns>
        Dictionary<string, DemFileReport> GenerateReport(string directoryPath, string urlToLstFile, string remoteFileExtension, string newRemoteFileExtension = null);

        void GenerateFileMetadata(string geoTiffFileName, bool generateBitmap, bool force);
    }
}